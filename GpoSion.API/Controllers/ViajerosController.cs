using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Helpers;
using GpoSion.API.hub;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GpoSion.API.Controllers
{
    [Authorize(Policy = "AlmacenMateriaPrimaRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class ViajerosController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        private readonly IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public ViajerosController(IGpoSionRepository repo, IMapper mapper, IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _mapper = mapper;
            _hubContext = hubContext;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetViajeros([FromQuery] ViajeroParams viajeroParams)
        {
            var viajeros = await _repo.GetViajeros(viajeroParams);
            var viajerosToReturn = _mapper.Map<IEnumerable<ViajeroToListDto>>(viajeros);
            return Ok(viajerosToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetViajero(int id)
        {
            var viajero = await _repo.GetViajero(id);
            var viajeroToReturn = _mapper.Map<ViajeroForDetailDto>(viajero);

            return Ok(viajeroToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutViajero(int id, ViajeroForPutDto viajeroFP)
        {
            var viajero = await _repo.GetViajero(id);
            if (viajero == null)
                return BadRequest();
            if (viajero.ViajeroId != viajeroFP.ViajeroId)
                return BadRequest();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var nvaExistencia = viajeroFP.Existencia - viajero.Existencia;

            var almacenes = await _repo.GetAreas();
            var almacen = almacenes.FirstOrDefault(a => a.NombreArea.ToLower() == "almacen");

            var existenciaMaterial = await _repo.GetExistenciaPorAreaMaterial(almacen.AreaId, viajero.Material.MaterialId);
            var movMaterial = new MovimientoMaterial { Fecha = DateTime.Now, Origen = almacen, Destino = almacen, Material = viajero.Material, Viajero = viajero, ViajeroId = viajero.ViajeroId, Cantidad = nvaExistencia, FechaCreacion = DateTime.Now, CreadoPorId = userId, MotivoMovimiento = viajeroFP.MotivoMovimiento, LocalidadId = viajeroFP.LocalidadId };

            movMaterial.ExistenciaInicial = existenciaMaterial.Existencia;

            var viajeros = await _repo.GetViajerosPorMaterial(viajero.Material.MaterialId);
            var existenciaCalculada = viajeros.Sum(v => v.Existencia);

            existenciaMaterial.Existencia = existenciaCalculada + nvaExistencia;
            existenciaMaterial.ModificadoPorId = userId;
            existenciaMaterial.UltimaModificacion = DateTime.Now;
            movMaterial.ExistenciaFinal = existenciaMaterial.Existencia;

            viajero.MovimientosMaterial.Add(movMaterial);

            if (existenciaMaterial.Existencia < viajero.Material.StockMinimo)
            {
                await _hubContext.Clients.All.BroadcastMessage("Warning", "El material " + viajero.Material.ClaveMaterial + " se esta acabando");
            }



            if (viajero.LocalidadId != viajeroFP.LocalidadId)
            {
                if (viajero.LocalidadId.HasValue)
                {

                    var localidadMaterialOriginal = await _repo.GetLocalidadMaterial(viajero.LocalidadId.Value, viajero.MaterialId);
                    if (localidadMaterialOriginal != null)
                    {
                        localidadMaterialOriginal.Existencia -= viajero.Existencia;
                        localidadMaterialOriginal.ModificadoPorId = userId;
                        localidadMaterialOriginal.UltimaModificacion = DateTime.Now;
                    }

                }


                var localidadMaterial = await _repo.GetLocalidadMaterial(viajeroFP.LocalidadId.Value, viajeroFP.MaterialId);
                if (localidadMaterial == null)
                {
                    localidadMaterial = new LocalidadMaterial { MaterialId = viajeroFP.MaterialId, LocalidadId = viajeroFP.LocalidadId.Value, Existencia = viajeroFP.Existencia, CreadoPorId = userId, FechaCreacion = DateTime.Now };
                    _repo.Add(localidadMaterial);
                }
                else
                {
                    localidadMaterial.Existencia += viajeroFP.Existencia;
                    localidadMaterial.ModificadoPorId = userId;
                    localidadMaterial.UltimaModificacion = DateTime.Now;
                }


            }
            else
            {
                var localidadMaterial = await _repo.GetLocalidadMaterial(viajeroFP.LocalidadId.Value, viajeroFP.MaterialId);

                localidadMaterial.Existencia += nvaExistencia;
                localidadMaterial.ModificadoPorId = userId;
                localidadMaterial.UltimaModificacion = DateTime.Now;
            }

            viajero.Existencia = viajeroFP.Existencia;
            viajero.LocalidadId = viajeroFP.LocalidadId;
            viajero.UltimaModificacion = DateTime.Now;
            viajero.ModificadoPorId = userId;



            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Viajero no guardado");
        }
    }
}
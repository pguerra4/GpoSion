using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{
    [Authorize(Policy = "AlmacenRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class ViajerosController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public ViajerosController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetViajeros()
        {
            var viajeros = await _repo.GetViajeros();
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

            existenciaMaterial.Existencia += nvaExistencia;

            var movMaterial = new MovimientoMaterial { Fecha = DateTime.Now, Origen = almacen, Destino = almacen, Material = viajero.Material, Viajero = viajero, ViajeroId = viajero.ViajeroId, Cantidad = nvaExistencia, FechaCreacion = DateTime.Now, CreadoPorId = userId, MotivoMovimiento = viajeroFP.MotivoMovimiento, LocalidadId = viajeroFP.LocalidadId };

            viajero.MovimientosMaterial.Add(movMaterial);

            if (viajero.LocalidadId != viajeroFP.LocalidadId)
            {
                if (viajero.LocalidadId.HasValue)
                {
                    var localidadOriginal = await _repo.GetLocalidad(viajero.LocalidadId.Value);
                    if (localidadOriginal != null)
                    {
                        var localidadMaterialOriginal = localidadOriginal.MaterialesLocalidad.Where(ml => ml.MaterialId == viajero.MaterialId).FirstOrDefault();
                        if (localidadMaterialOriginal != null)
                        {
                            localidadMaterialOriginal.Existencia -= viajero.Existencia;
                            localidadMaterialOriginal.ModificadoPorId = userId;
                            localidadMaterialOriginal.UltimaModificacion = DateTime.Now;
                        }
                    }
                }

                var localidad = await _repo.GetLocalidad(viajeroFP.LocalidadId.Value);
                if (localidad != null)
                {
                    var localidadMaterial = localidad.MaterialesLocalidad.Where(ml => ml.MaterialId == viajeroFP.MaterialId).FirstOrDefault();
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

            }
            else
            {
                var localidad = await _repo.GetLocalidad(viajeroFP.LocalidadId.Value);

                var localidadMaterial = localidad.MaterialesLocalidad.Where(ml => ml.MaterialId == viajeroFP.MaterialId).FirstOrDefault();

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
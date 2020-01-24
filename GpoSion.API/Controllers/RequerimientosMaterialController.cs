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

    [Authorize(Policy = "ProduccionAlmacen")]
    [Route("api/[controller]")]
    [ApiController]
    public class RequerimientosMaterialController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public RequerimientosMaterialController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetRequerimientos()
        {
            var requerimientos = await _repo.GetRequerimientosMaterial();
            var requerimientosToList = _mapper.Map<ICollection<RequerimientoMaterialForDetailDto>>(requerimientos);

            return Ok(requerimientosToList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequerimiento(int id)
        {
            var requerimiento = await _repo.GetRequerimientoMaterial(id);
            var requerimientoToReturn = _mapper.Map<RequerimientoMaterialForDetailDto>(requerimiento);

            return Ok(requerimientoToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostRequerimiento(RequerimientoforCreationDto requerimientoforCreationDto)
        {


            var req = _mapper.Map<RequerimientoMaterial>(requerimientoforCreationDto);
            var materiales = _mapper.Map<IEnumerable<RequerimientoMaterialMaterial>>(requerimientoforCreationDto.Materiales);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var nuevoReq = new RequerimientoMaterial { TurnoId = req.TurnoId, JefaLinea = req.JefaLinea, FechaCreacion = DateTime.Now, CreadoPorId = userId };

            _repo.Add(nuevoReq);
            await _repo.SaveAll();

            nuevoReq.Materiales = new List<RequerimientoMaterialMaterial>();



            foreach (RequerimientoMaterialMaterial rmm in materiales)
            {
                nuevoReq.Materiales.Add(rmm);
            }



            if (await _repo.SaveAll())
            {
                var reqToReturn = _mapper.Map<RequerimientoMaterialForDetailDto>(nuevoReq);
                return CreatedAtAction("GetRequerimiento", new { id = nuevoReq.RequerimientoMaterialId }, reqToReturn);
            }


            throw new Exception("Requerimiento no guardado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequerimiento(int id, RequerimientoforEditDto rfeDto)
        {
            var req = await _repo.GetRequerimientoMaterial(id);
            if (req == null)
                return BadRequest();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var areas = await _repo.GetAreas();
            var almacen = areas.FirstOrDefault(a => a.NombreArea.ToLower() == "almacen");
            var produccion = areas.FirstOrDefault(a => a.NombreArea.ToLower() == "producción");

            req.Fechaentrega = DateTime.Now;
            req.Recibio = rfeDto.Recibio;
            req.Almacenista = rfeDto.Almacenista;
            req.UltimaModificacion = DateTime.Now;
            req.ModificadoPorId = userId;

            foreach (RequerimientoMaterialMaterialForEditDto rmmDto in rfeDto.Items)
            {
                var rmm = req.Materiales.FirstOrDefault(r => r.Id == rmmDto.Id);
                if (rmm != null)
                {
                    rmm.CantidadEntregada += rmmDto.asurtir;
                    rmm.FechaEntrega = DateTime.Now;
                    rmm.ViajeroId = rmmDto.Viajero;



                    var material = await _repo.GetMaterial(rmm.MaterialId);

                    var mm = new MovimientoMaterial { Fecha = rmm.FechaEntrega.Value, Material = material, Cantidad = rmmDto.asurtir, Origen = almacen, Destino = produccion, ViajeroId = rmm.ViajeroId, RequerimientoMaterialMaterialId = req.RequerimientoMaterialId, RequerimientoMaterialMaterial = rmm, Recibo = null, FechaCreacion = DateTime.Now, CreadoPorId = userId };
                    _repo.Add(mm);

                    var existenciaAlmacen = await _repo.GetExistenciaPorAreaMaterial(almacen.AreaId, material.MaterialId);
                    existenciaAlmacen.Existencia -= rmmDto.asurtir;
                    existenciaAlmacen.UltimaModificacion = DateTime.Now;
                    existenciaAlmacen.ModificadoPorId = userId;

                    var existenciaProduccion = await _repo.GetExistenciaPorAreaMaterial(produccion.AreaId, material.MaterialId);
                    if (existenciaProduccion != null)
                    {
                        existenciaProduccion.Existencia += rmmDto.asurtir;
                        existenciaProduccion.UltimaModificacion = DateTime.Now;
                        existenciaProduccion.ModificadoPorId = userId;
                    }
                    else
                    {
                        existenciaProduccion = new ExistenciaMaterial { Material = material, Area = produccion, Existencia = rmmDto.asurtir, FechaCreacion = DateTime.Now, CreadoPorId = userId };
                        _repo.Add(existenciaProduccion);
                    }

                    var viajero = await _repo.GetViajero(rmmDto.Viajero);
                    viajero.Existencia -= rmmDto.asurtir;
                    viajero.UltimaModificacion = DateTime.Now;
                    viajero.ModificadoPorId = userId;

                    if (rmm.Cantidad <= rmm.CantidadEntregada)
                    {
                        rmm.Estatus = "Surtido";
                    }
                    else
                    {
                        rmm.Estatus = "Parcialmente Surtido";
                    }

                    await _repo.SaveAll();
                }
            }

            bool entregado = true;
            foreach (RequerimientoMaterialMaterial rmm in req.Materiales)
            {
                if (rmm.Cantidad > rmm.CantidadEntregada)
                    entregado = false;
            }
            if (entregado)
            {
                req.Estatus = "Surtido";
            }
            else
            {
                req.Estatus = "Parcialmente Surtido";
            }

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Movimientos no guardados");
        }

    }
}
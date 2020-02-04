using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Helpers;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{
    [Authorize(Policy = "ProduccionAlmacen")]
    [Route("api/[controller]")]
    [ApiController]
    public class RetornoMaterialController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public RetornoMaterialController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetRetornosMaterial([FromQuery] RetornoMaterialParams retornoParams)
        {
            var movimientos = await _repo.GetMovimientoMateriales(retornoParams);
            var movsToReturn = _mapper.Map<ICollection<RetornoMaterialToListDto>>(movimientos);
            return Ok(movsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRetornoMaterial(int Id)
        {
            var movimiento = await _repo.GetMovimientoMaterial(Id);
            var movToReturn = _mapper.Map<RetornoMaterialToListDto>(movimiento);

            return Ok(movToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostRetornoMaterial(RetornoMaterialToCreateDto retornoToCreate)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var areas = await _repo.GetAreas();
            var almacen = areas.FirstOrDefault(a => a.NombreArea.ToLower() == "almacen");
            var produccion = areas.FirstOrDefault(a => a.NombreArea.ToLower() == "producción");
            var material = await _repo.GetMaterial(retornoToCreate.MaterialId);

            var existencia = await _repo.GetExistenciaPorAreaMaterial(1, retornoToCreate.MaterialId);
            if (existencia == null)
            {
                existencia = new ExistenciaMaterial { Material = material, Area = almacen, CreadoPorId = userId, Existencia = retornoToCreate.Cantidad, FechaCreacion = DateTime.Now };
                _repo.Add(existencia);
            }
            else
            {
                existencia.Existencia += retornoToCreate.Cantidad;
                existencia.UltimaModificacion = DateTime.Now;
                existencia.ModificadoPorId = userId;
            }

            var localidad = await _repo.GetLocalidad(retornoToCreate.LocalidadId);
            if (localidad != null)
            {
                var localidadMaterial = localidad.MaterialesLocalidad.Where(lm => lm.MaterialId == retornoToCreate.MaterialId).FirstOrDefault();
                if (localidadMaterial == null)
                {
                    localidadMaterial = new LocalidadMaterial { LocalidadId = retornoToCreate.LocalidadId, MaterialId = retornoToCreate.MaterialId, Existencia = retornoToCreate.Cantidad, FechaCreacion = DateTime.Now, CreadoPorId = userId };
                    _repo.Add(localidadMaterial);
                }
                else
                {
                    localidadMaterial.Existencia += retornoToCreate.Cantidad;
                    localidadMaterial.UltimaModificacion = DateTime.Now;
                    localidadMaterial.ModificadoPorId = userId;
                }
            }

            var movimientoMaterial = new MovimientoMaterial
            {
                Fecha = DateTime.Now,
                Material = material,
                Cantidad = retornoToCreate.Cantidad,
                Origen = produccion,
                Destino = almacen,
                MotivoMovimiento = "Retorno Material",
                LocalidadId = retornoToCreate.LocalidadId,
                FechaCreacion = DateTime.Now,
                CreadoPorId = userId
            };

            _repo.Add(movimientoMaterial);

            if (await _repo.SaveAll())
            {
                var retToReturn = _mapper.Map<RetornoMaterialToListDto>(movimientoMaterial);
                return CreatedAtAction("GetRetornoMaterial", new { id = movimientoMaterial.MovimientoMaterialId }, retToReturn);
            }

            throw new Exception("Retorno de material no guardado");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutRetornoMaterial(int id, RetornoMaterialToEditDto movimientoFP)
        {
            var movimiento = await _repo.GetMovimientoMaterial(id);
            if (movimiento == null)
                return NotFound();
            if (movimiento.MovimientoMaterialId != movimientoFP.MovimientoMaterialId)
                return BadRequest("Ids no coinciden");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var diferencia = movimientoFP.Cantidad - movimiento.Cantidad;

            if (movimiento.LocalidadId != movimientoFP.LocalidadId)
            {
                if (movimiento.LocalidadId.HasValue)
                {
                    var localidadOriginal = await _repo.GetLocalidad(movimiento.LocalidadId.Value);
                    var localidadMaterialOriginal = localidadOriginal.MaterialesLocalidad.Where(ml => ml.MaterialId == movimiento.MaterialId).FirstOrDefault();
                    if (localidadMaterialOriginal != null)
                    {
                        localidadMaterialOriginal.Existencia -= movimiento.Cantidad;
                        localidadMaterialOriginal.ModificadoPorId = userId;
                        localidadMaterialOriginal.UltimaModificacion = DateTime.Now;
                    }
                }

                var localidad = await _repo.GetLocalidad(movimientoFP.LocalidadId);
                var localidadMaterial = localidad.MaterialesLocalidad.Where(ml => ml.MaterialId == movimientoFP.MaterialId).FirstOrDefault();
                if (localidadMaterial == null)
                {
                    localidadMaterial = new LocalidadMaterial { LocalidadId = movimientoFP.LocalidadId, MaterialId = movimientoFP.MaterialId, Existencia = movimientoFP.Cantidad, FechaCreacion = DateTime.Now, CreadoPorId = userId };
                    _repo.Add(localidadMaterial);
                }
                else
                {
                    localidadMaterial.Existencia += movimientoFP.Cantidad;
                    localidadMaterial.ModificadoPorId = userId;
                    localidadMaterial.UltimaModificacion = DateTime.Now;
                }
            }
            else
            {
                var localidad = await _repo.GetLocalidad(movimientoFP.LocalidadId);
                var localidadMaterial = localidad.MaterialesLocalidad.Where(ml => ml.MaterialId == movimientoFP.MaterialId).FirstOrDefault();
                localidadMaterial.Existencia += diferencia;
                localidadMaterial.ModificadoPorId = userId;
                localidadMaterial.UltimaModificacion = DateTime.Now;
            }

            if (movimiento.Material.MaterialId != movimientoFP.MaterialId)
            {
                var existenciaOriginal = await _repo.GetExistenciaPorAreaMaterial(1, movimiento.MaterialId.Value);

                existenciaOriginal.Existencia -= movimiento.Cantidad;
                existenciaOriginal.UltimaModificacion = DateTime.Now;
                existenciaOriginal.ModificadoPorId = userId;

                var existencia = await _repo.GetExistenciaPorAreaMaterial(1, movimientoFP.MaterialId);
                if (existencia == null)
                {
                    var areas = await _repo.GetAreas();
                    var almacen = areas.FirstOrDefault(a => a.NombreArea.ToLower() == "almacen");
                    var material = await _repo.GetMaterial(movimientoFP.MaterialId);
                    existencia = new ExistenciaMaterial { Material = material, Area = almacen, CreadoPorId = userId, Existencia = movimientoFP.Cantidad, FechaCreacion = DateTime.Now };
                    _repo.Add(existencia);
                }
                else
                {
                    existencia.Existencia += movimientoFP.Cantidad;
                    existencia.UltimaModificacion = DateTime.Now;
                    existencia.ModificadoPorId = userId;
                }

            }
            else
            {
                var existencia = await _repo.GetExistenciaPorAreaMaterial(1, movimientoFP.MaterialId);

                existencia.Existencia += diferencia;
                existencia.UltimaModificacion = DateTime.Now;
                existencia.ModificadoPorId = userId;

            }

            movimiento.MaterialId = movimientoFP.MaterialId;
            movimiento.LocalidadId = movimientoFP.LocalidadId;
            movimiento.Cantidad = movimientoFP.Cantidad;

            movimiento.ModificadoPorId = userId;
            movimiento.UltimaModificacion = DateTime.Now;

            await _repo.SaveAll();
            return NoContent();


        }
    }
}
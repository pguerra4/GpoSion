using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosProductoController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public MovimientosProductoController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetMovimientosProducto()
        {
            var movimientos = await _repo.GetMovimientosProducto();

            return Ok(movimientos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovimientoProducto(int Id)
        {
            var movimiento = await _repo.GetMovimientoProducto(Id);
            // var moldeToReturn = _mapper.Map<MoldeForDetailDto>(molde);

            return Ok(movimiento);
        }

        [HttpPost()]
        public async Task<IActionResult> PostMovimientoProducto(MovimientoProductoToCreateDto movimientoToCreate)
        {

            movimientoToCreate.TipoMovimiento = "Entrada Almacen";
            var movimientoProducto = _mapper.Map<MovimientoProducto>(movimientoToCreate);

            _repo.Add(movimientoProducto);

            var existencia = await _repo.GetExistenciaProducto(movimientoToCreate.NoParte);
            if (existencia == null)
            {
                existencia = new ExistenciaProducto { NoParte = movimientoToCreate.NoParte, PiezasCertificadas = movimientoToCreate.PiezasCertificadas, PiezasRechazadas = movimientoToCreate.PiezasRechazadas, UltimaModificacion = DateTime.Now };
                _repo.Add(existencia);
            }
            else
            {
                existencia.PiezasCertificadas += movimientoToCreate.PiezasCertificadas;
                existencia.PiezasRechazadas += movimientoToCreate.PiezasRechazadas;
                existencia.UltimaModificacion = DateTime.Now;
            }

            if (await _repo.SaveAll())
                return CreatedAtAction("GetMovimientoProducto", new { id = movimientoProducto.MovimientoProductoId }, movimientoProducto);

            throw new Exception("Movimiento de producto no guardado");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimientoProducto(int id, MovimientoProductoForPutDto movimientoFP)
        {
            var movimiento = await _repo.GetMovimientoProducto(id);
            if (movimiento == null)
                return NotFound();
            if (movimiento.MovimientoProductoId != movimientoFP.MovimientoProductoId)
                return BadRequest("Ids no coinciden");




            var existencia = await _repo.GetExistenciaProducto(movimientoFP.NoParte);
            if (existencia == null)
                return BadRequest("Número de parte incorrecto");


            existencia.PiezasCertificadas += (movimientoFP.PiezasCertificadas - movimiento.PiezasCertificadas);
            existencia.PiezasRechazadas += (movimientoFP.PiezasRechazadas - movimiento.PiezasRechazadas);
            existencia.UltimaModificacion = DateTime.Now;


            _mapper.Map(movimientoFP, movimiento);

            await _repo.SaveAll();
            return NoContent();


        }
    }
}
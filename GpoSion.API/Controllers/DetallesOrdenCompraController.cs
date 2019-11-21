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
    public class DetallesOrdenCompraController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public DetallesOrdenCompraController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleOrdenCompra(int id)
        {
            var ordenD = await _repo.GetOrdenCompraDetalle(id);
            var ordenDToReturn = _mapper.Map<OrdenCompraDetalleToListDto>(ordenD);

            return Ok(ordenDToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostDetalleOrdenCompra(OrdenCompraDetalleToListDto detalleOrdenCompra)
        {


            var orden = await _repo.GetOrdenCompra(detalleOrdenCompra.NoOrden);
            if (orden == null)
                return BadRequest("Número de orden no encontrado.");

            if (orden.NumerosParte.Any(d => d.NoParte == detalleOrdenCompra.NumeroParteNoParte))
                return BadRequest("Número de parte ya registrado.");

            var detalle = _mapper.Map<OrdenCompraDetalle>(detalleOrdenCompra);
            detalle.NumeroParte = null;

            orden.NumerosParte.Add(detalle);


            if (await _repo.SaveAll())
            {
                var detalleToReturn = _mapper.Map<OrdenCompraDetalleToListDto>(detalle);
                return CreatedAtAction("GetDetalleOrdenCompra", new { id = detalle.Id }, detalleToReturn);
            }


            return NoContent();
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleOrdenCompra(int id, OrdenCompraDetalleToListDto detalleOrdenCompra)
        {

            if (id != detalleOrdenCompra.Id)
                return BadRequest("Ids no coinciden");

            var ordenDFromRepo = await _repo.GetOrdenCompraDetalle(id);

            _mapper.Map(detalleOrdenCompra, ordenDFromRepo);


            await _repo.SaveAll();


            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleOrdenCompra(int id)
        {



            var ordenDFromRepo = await _repo.GetOrdenCompraDetalle(id);

            if (ordenDFromRepo.PiezasSurtidas > 0)
                return BadRequest("Este número de parte ya tiene piezas surtidas.");
            _repo.Delete(ordenDFromRepo);

            await _repo.SaveAll();


            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Fallo el borrado del detalle de la orden de compra.");
        }


    }
}
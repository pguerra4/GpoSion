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

    [Authorize(Policy = "VentasRole")]
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

            orden.Fecha = orden.Fecha.ToLocalTime();

            if (orden.NumerosParte.Any(d => d.NoParte == detalleOrdenCompra.NumeroParteNoParte))
                return BadRequest("Número de parte ya registrado.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var detalle = _mapper.Map<OrdenCompraDetalle>(detalleOrdenCompra);
            detalle.NumeroParte = null;
            if (detalle.FechaInicio.HasValue)
                detalle.FechaInicio = detalle.FechaInicio.Value.ToLocalTime();
            if (detalle.FechaFin.HasValue)
                detalle.FechaFin = detalle.FechaFin.Value.ToLocalTime();

            detalle.FechaCreacion = DateTime.Now;
            detalle.CreadoPorId = userId;

            orden.NumerosParte.Add(detalle);



            if (await _repo.SaveAll())
            {
                var hoc = new HistorialOrdenCompra { NoOrden = detalleOrdenCompra.NoOrden, OrdenCompraDetalleId = detalle.Id, CreadoPorId = userId, Fecha = DateTime.Now, Observaciones = detalleOrdenCompra.Observaciones };
                _repo.Add(hoc);
                await _repo.SaveAll();
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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var ordenDFromRepo = await _repo.GetOrdenCompraDetalle(id);

            _mapper.Map(detalleOrdenCompra, ordenDFromRepo);

            if (ordenDFromRepo.FechaInicio.HasValue)
                ordenDFromRepo.FechaInicio = ordenDFromRepo.FechaInicio.Value.ToLocalTime();
            if (ordenDFromRepo.FechaFin.HasValue)
                ordenDFromRepo.FechaFin = ordenDFromRepo.FechaFin.Value.ToLocalTime();

            ordenDFromRepo.UltimaModificacion = DateTime.Now;
            ordenDFromRepo.ModificadoPorId = userId;

            var hoc = new HistorialOrdenCompra { NoOrden = detalleOrdenCompra.NoOrden, OrdenCompraDetalleId = detalleOrdenCompra.Id, CreadoPorId = userId, Fecha = DateTime.Now, Observaciones = detalleOrdenCompra.Observaciones };
            _repo.Add(hoc);

            await _repo.SaveAll();


            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleOrdenCompra(int id)
        {



            var ordenDFromRepo = await _repo.GetOrdenCompraDetalle(id);

            if (ordenDFromRepo.PiezasSurtidas > 0)
                return BadRequest("Este número de parte ya tiene piezas surtidas.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var observacion = "Borrado del número de parte " + ordenDFromRepo.NoParte + " de la orden de compra " + ordenDFromRepo.NoOrden + " con el id " + ordenDFromRepo.Id + " Piezas autorizadas " + ordenDFromRepo.PiezasAutorizadas + " Precio " + ordenDFromRepo.Precio;
            var hoc = new HistorialOrdenCompra { NoOrden = ordenDFromRepo.NoOrden, CreadoPorId = userId, Fecha = DateTime.Now, Observaciones = observacion };
            _repo.Add(hoc);

            _repo.Delete(ordenDFromRepo);



            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Fallo el borrado del detalle de la orden de compra.");
        }


    }
}
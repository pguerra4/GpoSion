using System;
using System.Collections.Generic;
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
    public class OrdenesCompraController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public OrdenesCompraController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetOrdenesCompra()
        {
            var ordenesCompra = await _repo.GetOrdenesCompra();
            var ordenesToReturn = _mapper.Map<IEnumerable<OrdenCompraToListDto>>(ordenesCompra);
            return Ok(ordenesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdenCompra(long id)
        {
            var orden = await _repo.GetOrdenCompra(id);
            var ordenToReturn = _mapper.Map<OrdenCompraToListDto>(orden);

            return Ok(ordenToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostOrdenCompra(OrdenCompraToListDto ordenCompra)
        {
            ordenCompra.Fecha = ordenCompra.Fecha.ToLocalTime();
            var orden = _mapper.Map<OrdenCompra>(ordenCompra);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            foreach (var item in orden.NumerosParte)
            {
                item.NumeroParte = null;
                if (item.FechaInicio.HasValue)
                    item.FechaInicio = item.FechaInicio.Value.ToLocalTime();
                if (item.FechaFin.HasValue)
                    item.FechaFin = item.FechaFin.Value.ToLocalTime();

                item.UltimaModificacion = DateTime.Now;
            }

            orden.Cliente = null;
            orden.FechaCreacion = DateTime.Now;
            orden.CreadoPorId = userId;




            _repo.Add(orden);
            if (await _repo.SaveAll())
            {
                var hoc = new HistorialOrdenCompra { NoOrden = orden.NoOrden, CreadoPorId = userId, Fecha = DateTime.Now, Observaciones = "Nueva orden de compra" };
                _repo.Add(hoc);
                await _repo.SaveAll();

                var ordenToReturn = _mapper.Map<OrdenCompraToListDto>(orden);
                return CreatedAtAction("GetOrdenCompra", new { id = orden.NoOrden }, ordenToReturn);
            }


            throw new Exception("Orden de compra no guardada");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenCompra(long id, OrdenCompraToListDto ordenCompra)
        {

            if (id != ordenCompra.NoOrden)
                return BadRequest();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var ordenFromRepo = await _repo.GetOrdenCompra(id);

            ordenCompra.Fecha = ordenCompra.Fecha.ToLocalTime();

            _mapper.Map(ordenCompra, ordenFromRepo);

            ordenFromRepo.UltimaModificacion = DateTime.Now;
            ordenFromRepo.ModificadoPorId = userId;

            var hoc = new HistorialOrdenCompra { NoOrden = ordenFromRepo.NoOrden, CreadoPorId = userId, Fecha = DateTime.Now, Observaciones = ordenCompra.Observaciones };
            _repo.Add(hoc);

            await _repo.SaveAll();


            return NoContent();
        }

        [HttpGet("{noParte}/OrdenesCompraAbiertasXNumeroParte")]
        public async Task<IActionResult> GetOrdenesCompraAbiertasXNumeroParte(string noParte)
        {
            var ordenesCompra = await _repo.GetOrdenesCompraAbiertasXNumeroParte(noParte);
            var ordenesToReturn = _mapper.Map<IEnumerable<OrdenCompraToListDto>>(ordenesCompra);
            return Ok(ordenesToReturn);
        }

    }
}
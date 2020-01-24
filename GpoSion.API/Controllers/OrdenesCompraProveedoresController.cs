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


    [Authorize(Policy = "ComprasRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesCompraProveedoresController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public OrdenesCompraProveedoresController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetOrdenesCompraProveedores()
        {
            var ordenes = await _repo.GetOrdenesCompraProveedores();
            var ordenesToReturn = _mapper.Map<IEnumerable<OrdenCompraProveedorToListDto>>(ordenes);
            return Ok(ordenesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdenCompraProveedor(string noOrden)
        {
            var orden = await _repo.GetOrdenCompraProveedor(noOrden);
            var ordenToReturn = _mapper.Map<OrdenCompraProveedorToListDto>(orden);

            return Ok(ordenToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostOrdenCompra(OrdenCompraProveedorToListDto ordenCompra)
        {
            var orden = _mapper.Map<OrdenCompraProveedor>(ordenCompra);
            orden.Fecha = orden.Fecha.ToLocalTime();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (orden.FechaEntrega.HasValue)
            {
                orden.FechaEntrega = orden.FechaEntrega.Value.ToLocalTime();
            }

            foreach (var item in orden.Materiales)
            {
                item.Material = null;
                item.FechaCreacion = DateTime.Now;
                item.CreadoPorId = userId;
            }

            orden.Proveedor = null;
            orden.Comprador = null;
            orden.FechaCreacion = DateTime.Now;
            orden.CreadoPorId = userId;

            _repo.Add(orden);
            if (await _repo.SaveAll())
            {
                var ordenToReturn = _mapper.Map<OrdenCompraProveedorToListDto>(orden);
                return CreatedAtAction("GetOrdenCompraProveedor", new { id = orden.NoOrden }, ordenToReturn);
            }


            throw new Exception("Orden de compra a proveedor no guardada");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenCompraProveedor(string noOrden, OrdenCompraProveedorToListDto ordenCompra)
        {

            if (noOrden != ordenCompra.NoOrden)
                return BadRequest("No. Orden no coincide.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var ordenFromRepo = await _repo.GetOrdenCompraProveedor(noOrden);

            _mapper.Map(ordenCompra, ordenFromRepo);

            ordenFromRepo.Fecha = ordenFromRepo.Fecha.ToLocalTime();

            if (ordenFromRepo.FechaEntrega.HasValue)
            {
                ordenFromRepo.FechaEntrega = ordenFromRepo.FechaEntrega.Value.ToLocalTime();
            }

            ordenFromRepo.UltimaModificacion = DateTime.Now;
            ordenFromRepo.ModificadoPorId = userId;

            await _repo.SaveAll();


            return NoContent();
        }



    }
}
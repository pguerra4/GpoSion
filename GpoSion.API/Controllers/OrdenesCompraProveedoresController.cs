using System;
using System.Collections.Generic;
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

            foreach (var item in orden.Materiales)
            {
                item.Material = null;
            }

            orden.Proveedor = null;
            orden.Comprador = null;

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

            var ordenFromRepo = await _repo.GetOrdenCompraProveedor(noOrden);

            _mapper.Map(ordenCompra, ordenFromRepo);



            await _repo.SaveAll();


            return NoContent();
        }



    }
}
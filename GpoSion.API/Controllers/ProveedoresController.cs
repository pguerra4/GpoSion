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
    public class ProveedoresController : ControllerBase
    {

        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public ProveedoresController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetProveedores()
        {
            var proveedores = await _repo.GetProveedores();
            var proveedoresToReturn = _mapper.Map<IEnumerable<ProveedorForListDto>>(proveedores);

            return Ok(proveedoresToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProveedor(int id)
        {
            var proveedor = await _repo.GetProveedor(id);
            var proveedorToReturn = _mapper.Map<ProveedorForDetailDto>(proveedor);

            return Ok(proveedorToReturn);
        }


        [HttpPost]
        public async Task<IActionResult> PostProveedor(ProveedorToCreateDto proveedorDto)
        {

            var proveedor = _mapper.Map<Proveedor>(proveedorDto);

            _repo.Add(proveedor);

            if (await _repo.SaveAll())
            {
                var proveedorToReturn = _mapper.Map<ProveedorForDetailDto>(proveedor);
                return CreatedAtAction("GetProveedor", new { id = proveedor.ProveedorId }, proveedorToReturn);
            }


            throw new Exception("Proveedor no guardado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, ProveedorForPutDto proveedorDto)
        {

            if (id != proveedorDto.ProveedorId)
                return BadRequest("Ids no coinciden.");


            var proveedor = await _repo.GetProveedor(id);
            if (proveedor == null)
                return NotFound();

            _mapper.Map(proveedorDto, proveedor);

            await _repo.SaveAll();
            return NoContent();
        }

    }
}
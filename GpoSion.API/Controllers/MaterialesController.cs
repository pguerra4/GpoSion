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
    public class MaterialesController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public MaterialesController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetMateriales()
        {
            var materiales = await _repo.GetMateriales();
            // var clientesToReturn = _mapper.Map<IEnumerable<ClienteForListDto>>(clientes);
            return Ok(materiales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterial(int id)
        {
            var material = await _repo.GetMaterial(id);
            // var clienteToReturn = _mapper.Map<ClienteForDetailDto>(cliente);

            return Ok(material);
        }

        [HttpPost()]
        public async Task<IActionResult> PostMaterial(MaterialforPostDto materialDto)
        {
            var cliente = await _repo.GetCliente(materialDto.ClienteId);
            var um = await _repo.GetUnidadMedida(materialDto.UnidadMedidaId);

            var material = new Material { Cliente = cliente, UnidadMedida = um, FechaCreacion = DateTime.Now, ClaveMaterial = materialDto.ClaveMaterial, Descripcion = materialDto.Descripcion };
            // _mapper.Map(materialDto, material);

            _repo.Add(material);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetMaterial", new { id = material.MaterialId }, material);

            throw new Exception("Material no guardado");
        }

    }
}
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
    [Authorize(Policy = "AlmacenRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposMaterialController : ControllerBase
    {

        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public TiposMaterialController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetTiposMaterial()
        {
            var tiposMaterial = await _repo.GetTiposMaterial();

            return Ok(tiposMaterial);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoMaterial(int id)
        {
            var tipoMaterial = await _repo.GetTipoMaterial(id);

            return Ok(tipoMaterial);
        }


        [HttpPost]
        public async Task<IActionResult> PostTipoMaterial(TipoMaterialToCreateDto tipoMaterialDto)
        {
            if (await _repo.ExisteTipoMaterial(tipoMaterialDto.Tipo))
                return BadRequest();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tipoMaterial = _mapper.Map<TipoMaterial>(tipoMaterialDto);

            tipoMaterial.CreadoPorId = userId;
            tipoMaterial.FechaCreacion = DateTime.Now;

            _repo.Add(tipoMaterial);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetTipoMaterial", new { id = tipoMaterial.TipoMaterialId }, tipoMaterial);

            throw new Exception("Tipo material no guardado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoMaterial(int id, TipoMaterialToEditDto tipoMaterialDto)
        {

            if (id != tipoMaterialDto.TipoMaterialId)
                return BadRequest();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var tipoMaterialFromRepo = await _repo.GetTipoMaterial(id);

            _mapper.Map(tipoMaterialDto, tipoMaterialFromRepo);

            tipoMaterialFromRepo.ModificadoPorId = userId;
            tipoMaterialFromRepo.UltimaModificacion = DateTime.Now;

            await _repo.SaveAll();
            return NoContent();
        }

    }
}
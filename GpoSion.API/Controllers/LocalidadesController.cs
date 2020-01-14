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
    public class LocalidadesController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public LocalidadesController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetLocalidades()
        {
            var localidades = await _repo.GetLocalidades();
            var localidadesToReturn = _mapper.Map<IEnumerable<LocalidadToListDto>>(localidades);
            return Ok(localidadesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocalidad(int id)
        {
            var localidad = await _repo.GetLocalidad(id);
            var localidadToReturn = _mapper.Map<LocalidadToListDto>(localidad);

            return Ok(localidadToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> PostLocalidad(LocalidadToCreateDto localidadDto)
        {
            if (await _repo.ExisteLocalidad(localidadDto.Descripcion))
                return BadRequest("Localidad ya existe");

            var localidad = _mapper.Map<Localidad>(localidadDto);

            _repo.Add(localidad);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetLocalidad", new { id = localidad.LocalidadId }, localidad);

            throw new Exception("Localidad no guardada");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalidad(int id, LocalidadToEditDto localidadDto)
        {

            if (id != localidadDto.LocalidadId)
                return BadRequest("No coinciden los ids");

            var localidadFromRepo = await _repo.GetLocalidad(id);

            _mapper.Map(localidadDto, localidadFromRepo);

            await _repo.SaveAll();
            return NoContent();
        }

    }
}
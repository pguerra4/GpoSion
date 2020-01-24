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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var localidad = _mapper.Map<Localidad>(localidadDto);
            localidad.CreadoPorId = userId;

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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var localidadFromRepo = await _repo.GetLocalidad(id);
            localidadFromRepo.UltimaModificacion = DateTime.Now;
            localidadFromRepo.ModificadoPorId = userId;

            _mapper.Map(localidadDto, localidadFromRepo);

            await _repo.SaveAll();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalidad(int id)
        {



            var localidadFromRepo = await _repo.GetLocalidad(id);

            if (localidadFromRepo == null)
                return NotFound();

            _repo.Delete(localidadFromRepo);



            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Fallo el borrado de la localidad " + localidadFromRepo.Descripcion + " probablemente ya este asignada a viajeros o recibos.");
        }

    }
}
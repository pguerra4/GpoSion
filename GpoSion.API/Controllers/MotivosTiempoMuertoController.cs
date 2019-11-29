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
    public class MotivostiempoMuertoController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public MotivostiempoMuertoController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetMotivosTiempoMuerto()
        {
            var motivos = await _repo.GetMotivosTiempoMuerto();

            return Ok(motivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotivoTiempoMuerto(int id)
        {
            var motivo = await _repo.GetMotivoTiempoMuerto(id);


            return Ok(motivo);
        }

        [HttpPost()]
        public async Task<IActionResult> PostMotivoTiempoMuerto(MotivoTiempoMuerto motivo)
        {



            _repo.Add(motivo);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetMotivoTiempoMuerto", new { id = motivo.MotivoTiempoMuertoId }, motivo);

            throw new Exception("Motivo tiempo muerto no guardado");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotivoTiempoMuerto(int id, MotivoTiempoMuerto motivo)
        {
            var motivoFromRepo = await _repo.GetMotivoTiempoMuerto(id);
            if (motivoFromRepo == null)
                return BadRequest();
            if (motivoFromRepo.MotivoTiempoMuertoId != motivo.MotivoTiempoMuertoId)
                return BadRequest();

            motivoFromRepo.Motivo = motivo.Motivo;

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Motivo tiempo muerto no guardado");
        }
    }
}
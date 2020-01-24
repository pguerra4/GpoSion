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

    [Authorize(Policy = "ProduccionRole")]
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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            motivo.CreadoPorId = userId;
            motivo.FechaCreacion = DateTime.Now;

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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            motivoFromRepo.Motivo = motivo.Motivo;
            motivoFromRepo.ModificadoPorId = userId;
            motivoFromRepo.UltimaModificacion = DateTime.Now;


            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Motivo tiempo muerto no guardado");
        }
    }
}
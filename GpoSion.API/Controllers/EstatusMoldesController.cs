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


    [Route("api/[controller]")]
    [ApiController]
    public class EstatusMoldesController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public EstatusMoldesController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetEstatusMoldes()
        {
            var estatusMoldes = await _repo.GetEstatusMoldes();
            var estatusToReturn = _mapper.Map<IEnumerable<EstatusMoldeToListDto>>(estatusMoldes);
            return Ok(estatusToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstatusMolde(int id)
        {
            var estatusMolde = await _repo.GetEstatusMolde(id);
            var estatusToReturn = _mapper.Map<EstatusMoldeToListDto>(estatusMolde);

            return Ok(estatusToReturn);
        }

        [Authorize(Policy = "ProduccionAlmacen")]
        [HttpPost()]
        public async Task<IActionResult> PostEstatusMolde(EstatusMoldeToCreateDto estatusMoldeforCreationDto)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            estatusMoldeforCreationDto.Estatus = estatusMoldeforCreationDto.Estatus.Trim();

            var estatusMolde = _mapper.Map<EstatusMolde>(estatusMoldeforCreationDto);
            estatusMolde.FechaCreacion = DateTime.Now;
            estatusMolde.CreadoPorId = userId;

            _repo.Add(estatusMolde);



            if (await _repo.SaveAll())
            {
                var moldeToReturn = _mapper.Map<EstatusMoldeToListDto>(estatusMolde);
                return CreatedAtAction("GetEstatusMolde", new { id = estatusMolde.EstatusMoldeId }, moldeToReturn);
            }


            throw new Exception("Estatus del molde no guardado");
        }


        [Authorize(Policy = "ProduccionAlmacen")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstatusMolde(int id, EstatusMoldeToListDto estatusMoldeFP)
        {
            var estatusMolde = await _repo.GetEstatusMolde(id);
            if (estatusMolde == null)
                return NotFound();
            if (estatusMolde.EstatusMoldeId != estatusMoldeFP.EstatusMoldeId)
                return BadRequest("Ids no coinciden");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            estatusMolde.Estatus = estatusMoldeFP.Estatus.Trim();
            estatusMolde.UltimaModificacion = DateTime.Now; ;
            estatusMolde.ModificadoPorId = userId;



            await _repo.SaveAll();
            return NoContent();

            throw new Exception("Estatus del molde no guardado");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstatusMolde(int id)
        {



            var estatusMoldeFromRepo = await _repo.GetEstatusMolde(id);

            if (estatusMoldeFromRepo == null)
                return NotFound();

            _repo.Delete(estatusMoldeFromRepo);



            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest("Fallo el borrado del estatus de molde " + estatusMoldeFromRepo.Estatus + " probablemente ya tenga moldes y/o movimientos asignados.");
        }
    }
}
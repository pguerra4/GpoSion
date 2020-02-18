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

            return Ok(estatusMolde);
        }

        [Authorize(Policy = "ProduccionAlmacen")]
        [HttpPost()]
        public async Task<IActionResult> PostMolde(MoldeForCreationDto moldeforCreationDto)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var molde = _mapper.Map<Molde>(moldeforCreationDto);
            molde.FechaCreacion = DateTime.Now;
            molde.CreadoPorId = userId;

            _repo.Add(molde);

            int estatusId = 1;
            if (moldeforCreationDto.UbicacionAreaId == 2)
                estatusId = 2;

            var movimientoMolde = new MovimientoMolde { EstatusMoldeId = estatusId, Molde = molde, Fecha = DateTime.Now, FechaCreacion = DateTime.Now, CreadoPorId = userId, Observaciones = "Alta de molde en sistema" };

            _repo.Add(movimientoMolde);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetMolde", new { id = molde.Id }, molde);

            throw new Exception("Molde no guardado");
        }


        [Authorize(Policy = "ProduccionAlmacen")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMolde(int id, MoldeForPutDto moldeFP)
        {
            var molde = await _repo.GetMolde(id);
            if (molde == null)
                return BadRequest();
            if (molde.Id != moldeFP.Id)
                return BadRequest();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            molde.ClaveMolde = moldeFP.ClaveMolde;
            molde.ClienteId = moldeFP.ClienteId;
            molde.UbicacionAreaId = moldeFP.UbicacionAreaId;
            // molde.MaquinaMoldeadoraId = moldeFP.MaquinaMoldeadoraId;
            molde.UltimaModificacion = moldeFP.UltimaModificacion;
            molde.ModificadoPorId = userId;

            if (molde.EstatusMoldeId != moldeFP.EstatusMoldeId || moldeFP.Observaciones.Trim() != "")
            {
                var movimientoMolde = new MovimientoMolde { EstatusMoldeId = moldeFP.EstatusMoldeId.Value, MoldeId = moldeFP.Id, Fecha = moldeFP.Fecha.Value, FechaCreacion = DateTime.Now, CreadoPorId = userId, Observaciones = moldeFP.Observaciones };

                _repo.Add(movimientoMolde);

                molde.EstatusMoldeId = moldeFP.EstatusMoldeId;
            }

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Molde no guardado");
        }

        [HttpGet("{molde}/Existe")]
        public async Task<IActionResult> ExisteMolde(string molde)
        {

            return Ok(await _repo.ExisteMolde(molde));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMolde(int id)
        {



            var moldeFromRepo = await _repo.GetMolde(id);

            if (moldeFromRepo == null)
                return NotFound();

            _repo.Delete(moldeFromRepo);



            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest("Fallo el borrado del molde " + moldeFromRepo.ClaveMolde + " probablemente ya tenga movimientos asignados.");
        }
    }
}
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
    public class MoldesController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public MoldesController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetMoldes()
        {
            var moldes = await _repo.GetMoldes();
            var moldesToReturn = _mapper.Map<IEnumerable<MoldeToListDto>>(moldes);
            return Ok(moldesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMolde(int id)
        {
            var molde = await _repo.GetMolde(id);
            var moldeToReturn = _mapper.Map<MoldeForDetailDto>(molde);

            return Ok(moldeToReturn);
        }

        [Authorize(Policy = "ProduccionAlmacen")]
        [HttpPost()]
        public async Task<IActionResult> PostMolde(MoldeForCreationDto moldeforCreationDto)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            moldeforCreationDto.ClaveMolde = moldeforCreationDto.ClaveMolde.Trim();

            var molde = _mapper.Map<Molde>(moldeforCreationDto);
            molde.FechaCreacion = DateTime.Now;
            molde.CreadoPorId = userId;



            int estatusId = 1;
            if (moldeforCreationDto.UbicacionAreaId == 2)
                estatusId = 2;

            var movimientoMolde = new MovimientoMolde { EstatusMoldeId = estatusId, Molde = molde, Fecha = DateTime.Now, FechaCreacion = DateTime.Now, CreadoPorId = userId, Observaciones = "Alta de molde en sistema" };

            molde.EstatusMoldeId = estatusId;
            _repo.Add(molde);
            _repo.Add(movimientoMolde);

            if (await _repo.SaveAll())
            {
                var moldeToReturn = _mapper.Map<MoldeToListDto>(molde);
                return CreatedAtAction("GetMolde", new { id = molde.Id }, moldeToReturn);
            }


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


            molde.ClaveMolde = moldeFP.ClaveMolde.Trim();
            molde.ClienteId = moldeFP.ClienteId;
            molde.UbicacionAreaId = moldeFP.UbicacionAreaId;
            // molde.MaquinaMoldeadoraId = moldeFP.MaquinaMoldeadoraId;
            molde.UltimaModificacion = moldeFP.UltimaModificacion;
            molde.ModificadoPorId = userId;

            if (molde.EstatusMoldeId != moldeFP.EstatusMoldeId)
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
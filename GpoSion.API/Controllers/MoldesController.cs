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

        [HttpPost()]
        public async Task<IActionResult> PostMolde(MoldeForCreationDto moldeforCreationDto)
        {


            var molde = _mapper.Map<Molde>(moldeforCreationDto);

            _repo.Add(molde);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetMolde", new { id = molde.Id }, molde);

            throw new Exception("Molde no guardado");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutMolde(int id, MoldeForPutDto moldeFP)
        {
            var molde = await _repo.GetMolde(id);
            if (molde == null)
                return BadRequest();
            if (molde.Id != moldeFP.Id)
                return BadRequest();

            molde.ClaveMolde = moldeFP.ClaveMolde;
            molde.ClienteId = moldeFP.ClienteId;
            molde.UbicacionAreaId = moldeFP.UbicacionAreaId;
            molde.MaquinaMoldeadoraId = moldeFP.MaquinaMoldeadoraId;
            molde.UltimaModificacion = moldeFP.UltimaModificacion;



            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Molde no guardado");
        }
    }
}
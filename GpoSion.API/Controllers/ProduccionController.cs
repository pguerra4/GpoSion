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
    public class ProduccionController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public ProduccionController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetProducciones()
        {
            var moldes = await _repo.GetMoldes();
            var moldesToReturn = _mapper.Map<IEnumerable<MoldeToListDto>>(moldes);
            return Ok(moldesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduccion(int id)
        {
            var molde = await _repo.GetMolde(id);
            var moldeToReturn = _mapper.Map<MoldeForDetailDto>(molde);

            return Ok(moldeToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostProduccion(ProduccionToCreateDto produccionToCreateDto)
        {


            var prod = _mapper.Map<Produccion>(produccionToCreateDto);

            _repo.Add(prod);

            if (await _repo.SaveAll())
            {
                var prodtoReturn = _mapper.Map<ProduccionForDetailDto>(prod);
                return CreatedAtAction("GetProduccion", new { id = prod.ProduccionId }, prodtoReturn);
            }


            throw new Exception("Captura de producción no guardada");
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
            // molde.MaquinaMoldeadoraId = moldeFP.MaquinaMoldeadoraId;
            molde.UltimaModificacion = moldeFP.UltimaModificacion;



            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Molde no guardado");
        }
    }
}
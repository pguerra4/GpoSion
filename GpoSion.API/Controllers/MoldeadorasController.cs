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
    public class MoldeadorasController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public MoldeadorasController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetMoldeadoras()
        {
            var moldeadoras = await _repo.GetMoldeadoras();
            var moldeadorasToReturn = _mapper.Map<IEnumerable<MoldeadoraToListDto>>(moldeadoras);
            return Ok(moldeadorasToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMoldeadora(int id)
        {
            var moldeadora = await _repo.GetMoldeadora(id);
            var moldeadoraToReturn = _mapper.Map<MoldeadoraToListDto>(moldeadora);

            return Ok(moldeadoraToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostMolde(MoldeadoraToCreateDto moldeadoraToCreateDto)
        {


            var moldeadora = _mapper.Map<Moldeadora>(moldeadoraToCreateDto);
            moldeadora.Estatus = "Detenida";
            _repo.Add(moldeadora);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetMoldeadora", new { id = moldeadora.MoldeadoraId }, moldeadora);

            throw new Exception("Moldeadora no guardada");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutMolde(int id, MoldeadoraForPutDto moldeadoraFP)
        {
            var moldeadora = await _repo.GetMoldeadora(id);
            if (moldeadora == null)
                return BadRequest();
            if (moldeadora.MoldeadoraId != moldeadoraFP.MoldeadoraId)
                return BadRequest();

            moldeadora.MoldeId = moldeadoraFP.MoldeId;
            moldeadora.MaterialId = moldeadoraFP.MaterialId;
            moldeadora.Estatus = moldeadoraFP.Estatus;

            moldeadora.MoldeadoraNumerosParte.Clear();


            foreach (var item in moldeadoraFP.NumerosParte)
            {
                moldeadora.MoldeadoraNumerosParte.Add(new MoldeadoraNumeroParte { NoParte = item, MoldeadoraId = moldeadora.MoldeadoraId });
            }



            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Moldeadora no guardada");
        }
    }
}
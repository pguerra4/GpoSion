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
    public class NumerosParteController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public NumerosParteController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetNumerosParte()
        {
            var numerosParte = await _repo.GetNumerosParte();
            var numerosParteToReturn = _mapper.Map<IEnumerable<NumeroParteToListDto>>(numerosParte);
            return Ok(numerosParteToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNumeroParte(string id)
        {
            var numeroParte = await _repo.GetNumeroParte(id);
            var numeroParteToReturn = _mapper.Map<NumeroParteToListDto>(numeroParte);

            return Ok(numeroParteToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostNumeroParte(NumeroParteToCreateDto numeroParteforCreationDto)
        {


            var numeroParte = _mapper.Map<NumeroParte>(numeroParteforCreationDto);

            _repo.Add(numeroParte);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetNumeroParte", new { id = numeroParte.NoParte }, numeroParte);

            throw new Exception("Numero de parte no guardado");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumeroParte(string id, NumeroParteToCreateDto numeroParteFP)
        {
            var numeroParte = await _repo.GetNumeroParte(id);
            if (numeroParte == null)
                return BadRequest();
            if (numeroParte.NoParte != numeroParteFP.NoParte)
                return BadRequest();


            numeroParte.ClienteId = numeroParteFP.ClienteId;
            numeroParte.MaterialId = numeroParteFP.MaterialId;
            numeroParte.Peso = numeroParteFP.Peso;
            numeroParte.Costo = numeroParteFP.Costo;
            numeroParte.Descripcion = numeroParteFP.Descripcion;
            numeroParte.LeyendaPieza = numeroParteFP.LeyendaPieza;

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Numero de parte no guardado");
        }
    }
}
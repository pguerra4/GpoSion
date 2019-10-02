using System;
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
    public class RecibosController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public RecibosController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }


        [HttpGet]
        public async Task<IActionResult> GetRecibos()
        {
            var recibos = await _repo.GetRecibos();

            return Ok(recibos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecibo(int id)
        {
            var recibo = await _repo.GetRecibo(id);
            // var clienteToReturn = _mapper.Map<ClienteForDetailDto>(cliente);

            return Ok(recibo);
        }

        [HttpPost()]
        public async Task<IActionResult> PostRecibo(ReciboForCreationDto reciboforCreationDto)
        {


            var recibo = _mapper.Map<Recibo>(reciboforCreationDto);

            _repo.Add(recibo);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetRecibo", new { id = recibo.ReciboId }, recibo);

            throw new Exception("Recibo no guardado");
        }

    }
}
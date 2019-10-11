using System;
using System.Collections.Generic;
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
            var recibostoList = _mapper.Map<ICollection<ReciboToListDto>>(recibos);

            return Ok(recibostoList);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecibo(int id)
        {
            var recibo = await _repo.GetRecibo(id);
            var reciboToReturn = _mapper.Map<ReciboToDetailDto>(recibo);

            return Ok(reciboToReturn);
        }

        [HttpGet("{id}/existe")]
        public async Task<IActionResult> ExisteRecibo(int id)
        {
            return Ok(await _repo.ExisteRecibo(id));
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
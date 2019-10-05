using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExistenciasController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public ExistenciasController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetExistencias()
        {
            var existencias = await _repo.GetExistencias();
            var existenciasToReturn = _mapper.Map<IEnumerable<ExistenciaMaterialToListDto>>(existencias);
            return Ok(existenciasToReturn);
        }

        [HttpGet("/api/existenciasalmacen")]
        public async Task<IActionResult> GetExistenciasAlmacen()
        {
            var existencias = await _repo.GetExistenciasEnAlmacen();
            var existenciasToReturn = _mapper.Map<IEnumerable<ExistenciaMaterialToListDto>>(existencias);
            return Ok(existenciasToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExistencia(int id)
        {
            var existencia = await _repo.GetExistencia(id);
            // var clienteToReturn = _mapper.Map<ClienteForDetailDto>(cliente);

            return Ok(existencia);
        }

    }
}
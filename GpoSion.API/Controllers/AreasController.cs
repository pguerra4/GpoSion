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
    public class AreasController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public AreasController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetAreas()
        {
            var areas = await _repo.GetAreas();
            // var clientesToReturn = _mapper.Map<IEnumerable<ClienteForListDto>>(clientes);
            return Ok(areas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArea(int id)
        {
            var area = await _repo.GetArea(id);
            // var clienteToReturn = _mapper.Map<ClienteForDetailDto>(cliente);

            return Ok(area);
        }

    }
}
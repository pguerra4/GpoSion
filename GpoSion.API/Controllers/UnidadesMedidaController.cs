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
    public class UnidadesMedidaController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public UnidadesMedidaController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetUnidadesMedida()
        {
            var unidadesMedida = await _repo.GetUnidadesMedida();
            //var clientesToReturn = _mapper.Map<IEnumerable<ClienteForListDto>>(clientes);
            return Ok(unidadesMedida);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnidadMedida(int id)
        {
            var unidadMedida = await _repo.GetUnidadMedida(id);
            //var clienteToReturn = _mapper.Map<ClienteForDetailDto>(cliente);

            return Ok(unidadMedida);
        }

    }
}
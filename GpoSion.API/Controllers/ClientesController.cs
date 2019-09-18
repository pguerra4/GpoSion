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
    public class ClientesController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public ClientesController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _repo.GetClientes();
            var clientesToReturn = _mapper.Map<IEnumerable<ClienteForListDto>>(clientes);
            return Ok(clientesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _repo.GetCliente(id);
            var clienteToReturn = _mapper.Map<ClienteForDetailDto>(cliente);

            return Ok(clienteToReturn);
        }

    }
}
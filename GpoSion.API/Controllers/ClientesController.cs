using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy = "VentasRole")]
        [HttpPost()]
        public async Task<IActionResult> PostCliente(ClienteToCreateDto clienteDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            clienteDto.Clave = clienteDto.Clave.Trim();
            clienteDto.Nombre = clienteDto.Nombre.Trim();

            var cliente = _mapper.Map<Cliente>(clienteDto);
            cliente.CreadoPorId = userId;
            cliente.FechaCreacion = DateTime.Now;

            _repo.Add(cliente);
            if (await _repo.SaveAll())
            {
                var clienteToReturn = _mapper.Map<ClienteForDetailDto>(cliente);
                return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, clienteToReturn);
            }


            throw new Exception("Cliente no guardado");

        }

        [Authorize(Policy = "VentasRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteForPutDto clienteDto)
        {
            var cliente = await _repo.GetCliente(id);
            if (cliente == null)
                return NotFound();
            if (cliente.ClienteId != clienteDto.ClienteId)
                return BadRequest("Ids no coinciden.");

            clienteDto.Nombre = clienteDto.Nombre.Trim();
            clienteDto.Clave = clienteDto.Clave.Trim();

            _mapper.Map(clienteDto, cliente);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            cliente.ModificadoPorId = userId;
            cliente.UltimaModificacion = DateTime.Now;

            await _repo.SaveAll();
            return NoContent();


        }


    }
}
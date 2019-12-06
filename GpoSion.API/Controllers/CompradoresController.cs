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
    public class CompradoresController : ControllerBase
    {

        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public CompradoresController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetCompradores()
        {
            var compradores = await _repo.GetCompradores();
            // var CompradoresToReturn = _mapper.Map<IEnumerable<ProveedorForListDto>>(Compradores);

            return Ok(compradores);
        }



    }
}
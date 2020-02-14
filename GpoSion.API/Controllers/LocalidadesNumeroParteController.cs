using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using GpoSion.API.Models;

namespace GpoSion.API.Controllers
{


    [Authorize(Policy = "AlmacenRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesNumeroParteController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public LocalidadesNumeroParteController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }




        [HttpGet("{noParte}")]
        public async Task<IActionResult> GetLocalidadesNumeroParte(string noParte)
        {
            var localidadesNumeroParte = await _repo.GetLocalidadesNumeroParte(noParte);
            var localidadesToReturn = _mapper.Map<IEnumerable<LocalidadNumeroParteToListDto>>(localidadesNumeroParte);

            return Ok(localidadesToReturn);
        }

    }
}
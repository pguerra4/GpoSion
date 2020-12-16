using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{
    [Authorize(Policy = "AlmacenProductoProdRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoMaterialController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public MovimientoMaterialController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetMovimientosMaterials([FromQuery] MovimientoMaterialParams movimientoParams)
        {
            var movimientos = await _repo.GetMovimientosMaterial(movimientoParams);
            var movimientosToReturn = _mapper.Map<ICollection<MovimientoMaterialToListDto>>(movimientos);
            return Ok(movimientosToReturn);
        }
    }
}
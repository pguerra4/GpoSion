using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace GpoSion.API.Controllers
{


    [Authorize(Policy = "ProduccionAlmacen")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExistenciasProductoController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public ExistenciasProductoController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetExistenciasProducto()
        {
            var ExistenciasProducto = await _repo.GetExistenciasProducto();




            var existenciasToReturn = _mapper.Map<IEnumerable<ExistenciaProductoToListDto>>(ExistenciasProducto);
            return Ok(existenciasToReturn);
        }


        [HttpGet("{noParte}")]
        public async Task<IActionResult> GetExistenciasProducto(string noParte)
        {
            var existencia = await _repo.GetExistenciaProducto(noParte);
            var existenciaToReturn = _mapper.Map<ExistenciaProductoToListDto>(existencia);

            return Ok(existenciaToReturn);
        }

    }
}
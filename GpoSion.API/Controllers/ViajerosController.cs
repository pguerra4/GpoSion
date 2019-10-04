using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajerosController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public ViajerosController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetViajeros()
        {
            var areas = await _repo.GetAreas();
            // var clientesToReturn = _mapper.Map<IEnumerable<ClienteForListDto>>(clientes);
            return Ok(areas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetViajero(int id)
        {
            var viajero = await _repo.GetViajero(id);
            var viajeroToReturn = _mapper.Map<ViajeroForDetailDto>(viajero);

            return Ok(viajeroToReturn);
        }
    }
}
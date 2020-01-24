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


            var nuevasExistencias = existencias.GroupBy(e => e.Material).Select(m => new ExistenciasMaterialGroupToListDto
            {
                MaterialId = m.Key.MaterialId,
                Material = m.Key.ClaveMaterial,
                Almacen = m.Where(e => e.Area.NombreArea.ToLowerInvariant() == "almacen").Sum(e => e.Existencia),
                Produccion = m.Where(e => e.Area.NombreArea.ToLowerInvariant() == "producción").Sum(e => e.Existencia),
                UltimaModificacion = m.Max(e => e.UltimaModificacion.Value)
            }).Where(e => e.Almacen > 0 || e.Produccion > 0).OrderBy(e => e.UltimaModificacion);

            // var existenciasToReturn = _mapper.Map<IEnumerable<ExistenciaMaterialToListDto>>(nuevasExistencias);
            return Ok(nuevasExistencias);
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
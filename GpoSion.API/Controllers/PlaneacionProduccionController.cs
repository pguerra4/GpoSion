using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Helpers;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{
    [Authorize(Policy = "ProduccionRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneacionProduccionController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public PlaneacionProduccionController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetPlaneacionesProduccion([FromQuery] PlaneacionProduccionParams ppParams)
        {
            var planeaciones = await _repo.GetPlaneacionesProduccion(ppParams);
            var ppC = planeaciones.Select(pp => new
            {
                year = pp.año,
                semana = pp.semana,
                noParte = pp.NoParte,
                cantidad = pp.cantidad,
                existenciaAlmacen = pp.NumeroParte.ExistenciasProducto.Where(ep => ep.PiezasCertificadas > 0).Sum(ep => ep.PiezasCertificadas),
                existenciaProduccion = pp.NumeroParte.ExistenciasProductoProduccion.Where(epp => epp.PiezasCertificadas > 0).Sum(epp => epp.PiezasCertificadas)
            });

            // var planeacionesToReturn = _mapper.Map<IEnumerable<PlaneacionProduccionToCreateDto>>(planeaciones);
            return Ok(ppC);
        }

        [HttpGet("{año}/{semana}/{noParte}")]
        public async Task<IActionResult> GetPlaneacionProduccion(int año, int semana, string noParte)
        {
            var pp = await _repo.GetPlaneacionProduccion(año, semana, noParte);
            var ppToReturn = _mapper.Map<PlaneacionProduccionToCreateDto>(pp);

            return Ok(ppToReturn);
        }


        [HttpPost()]
        public async Task<IActionResult> PostPlaneacionProduccion(PlaneacionProduccionToCreateDto planeacionToCreateDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var ppRepo = await _repo.GetPlaneacionProduccion(planeacionToCreateDto.año, planeacionToCreateDto.semana, planeacionToCreateDto.NoParte);
            if (ppRepo != null)
                return BadRequest("La planeación para el No. Parte " + planeacionToCreateDto.NoParte + " de la semana " + planeacionToCreateDto.semana + " ya fue capturada.");

            var pp = _mapper.Map<PlaneacionProduccion>(planeacionToCreateDto);
            pp.CreadoPorId = userId;
            pp.FechaCreacion = DateTime.Now;

            _repo.Add(pp);

            if (await _repo.SaveAll())
            {
                var ppReturn = _mapper.Map<PlaneacionProduccionToCreateDto>(pp);
                return CreatedAtAction("GetPlaneacionProduccion", new { año = pp.año, semana = pp.semana, noParte = pp.NoParte }, ppReturn);
            }


            throw new Exception("Captura de planeación no guardada");
        }

        [HttpPut("{año}/{semana}/{noParte}")]
        public async Task<IActionResult> PutPlaneacionProduccion(int año, int semana, string noParte, PlaneacionProduccionToCreateDto planeacionToCreateDto)
        {
            var pp = await _repo.GetPlaneacionProduccion(año, semana, noParte);
            if (pp == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _mapper.Map(planeacionToCreateDto, pp);
            pp.ModificadoPorId = userId;
            pp.UltimaModificacion = DateTime.Now;
            await _repo.SaveAll();

            return NoContent();


        }

    }
}
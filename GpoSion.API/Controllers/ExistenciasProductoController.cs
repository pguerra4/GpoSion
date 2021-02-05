using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GpoSion.API.Models;
using System;

namespace GpoSion.API.Controllers
{


    [Authorize(Policy = "AlmacenProductoProdRole")]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExistenciasProducto(int id, ExistenciaProductoToEditDto existenciaFP)
        {
            var existencia = await _repo.GetExistenciaProductoPorId(id);
            if (existencia == null)
                return NotFound();
            if (existencia.ExistenciaProductoId != existenciaFP.ExistenciaProductoId)
                return BadRequest("Ids no coinciden.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var movimiento = new MovimientoProducto
            {
                NoParte = existencia.NoParte,
                PiezasCertificadas = existenciaFP.PiezasCertificadas,
                PiezasRechazadas = existenciaFP.PiezasRechazadas,
                ExistenciaAlmacenInicial = existencia.PiezasCertificadas,
                ExistenciaAlmacenFinal = existenciaFP.PiezasCertificadas,
                Fecha = DateTime.Now,
                FechaCreacion = DateTime.Now,
                CreadoPorId = userId,
                TipoMovimiento = "Ajuste existencia"
            };

            _repo.Add(movimiento);


            var ajuste = new AjusteInventarioProducto
            {
                Fecha = DateTime.Now,
                Motivo = existenciaFP.Motivo,
                CreadoPorId = userId,
                ExistenciaOriginal = existencia.PiezasCertificadas,
                ExistenciaFinal = existenciaFP.PiezasCertificadas,
                ExistenciaProductoId = existencia.ExistenciaProductoId,
                NoParte = existencia.NoParte
            };

            _repo.Add(ajuste);

            existencia.PiezasCertificadas = existenciaFP.PiezasCertificadas;
            existencia.PiezasRechazadas = existenciaFP.PiezasRechazadas;
            existencia.ModificadoPorId = userId;
            existencia.UltimaModificacion = DateTime.Now;

            await _repo.SaveAll();

            return NoContent();
        }

    }
}
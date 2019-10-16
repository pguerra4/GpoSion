using System;
using System.Collections.Generic;
using System.Linq;
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
            var viajeros = await _repo.GetViajeros();
            var viajerosToReturn = _mapper.Map<IEnumerable<ViajeroToListDto>>(viajeros);
            return Ok(viajerosToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetViajero(int id)
        {
            var viajero = await _repo.GetViajero(id);
            var viajeroToReturn = _mapper.Map<ViajeroForDetailDto>(viajero);

            return Ok(viajeroToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutViajero(int id, ViajeroForPutDto viajeroFP)
        {
            var viajero = await _repo.GetViajero(id);
            if (viajero == null)
                return BadRequest();
            if (viajero.ViajeroId != viajeroFP.ViajeroId)
                return BadRequest();

            var nvaExistencia = viajeroFP.Existencia - viajero.Existencia;

            var almacenes = await _repo.GetAreas();
            var almacen = almacenes.FirstOrDefault(a => a.NombreArea.ToLower() == "almacen");

            var existenciaMaterial = await _repo.GetExistenciaPorAreaMaterial(almacen.AreaId, viajero.Material.MaterialId);

            existenciaMaterial.Existencia += nvaExistencia;

            var movMaterial = new MovimientoMaterial { Fecha = DateTime.Now, Origen = almacen, Destino = almacen, Material = viajero.Material, Viajero = viajero, ViajeroId = viajero.ViajeroId, Cantidad = nvaExistencia };

            viajero.MovimientosMaterial.Add(movMaterial);

            viajero.Existencia = viajeroFP.Existencia;
            viajero.Localidad = viajeroFP.Localidad;




            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Viajero no guardado");
        }
    }
}
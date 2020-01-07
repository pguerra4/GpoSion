using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Helpers;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GpoSion.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MaterialesController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public MaterialesController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetMateriales([FromQuery] MaterialParams materialParams)
        {
            var materiales = await _repo.GetMateriales(materialParams);
            var materialesToReturn = _mapper.Map<IEnumerable<MaterialtoListDto>>(materiales);
            return Ok(materialesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterial(int id)
        {
            var material = await _repo.GetMaterial(id);
            var materialToReturn = _mapper.Map<MaterialtoListDto>(material);

            return Ok(materialToReturn);
        }

        [HttpGet("{id}/viajeros")]
        public async Task<IActionResult> GetViajerosPorMaterial(int id)
        {
            var viajeros = await _repo.GetViajerosPorMaterial(id);
            if (viajeros == null || viajeros.FirstOrDefault() == null)
            {
                var existenciasMat = await _repo.GetExistenciaPorAreaMaterial(1, id);
                if (existenciasMat != null)
                {
                    var viajero = new Viajero { ViajeroId = 0, MaterialId = id, Material = existenciasMat.Material, Existencia = existenciasMat.Existencia };
                    viajeros = null;
                    var viajeros2 = new List<Viajero>();
                    viajeros2.Add(viajero);
                    viajeros = viajeros2;
                }

            }


            var viajerosToReturn = _mapper.Map<IEnumerable<ViajeroForDetailDto>>(viajeros);

            return Ok(viajerosToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostMaterial(MaterialforPostDto materialDto)
        {

            var um = await _repo.GetUnidadMedida(materialDto.UnidadMedidaId);

            var material = new Material { UnidadMedida = um, FechaCreacion = DateTime.Now, ClaveMaterial = materialDto.ClaveMaterial, Descripcion = materialDto.Descripcion, TipoMaterialId = materialDto.TipoMaterialId };
            // _mapper.Map(materialDto, material);

            _repo.Add(material);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetMaterial", new { id = material.MaterialId }, material);

            throw new Exception("Material no guardado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, MaterialForPutDto materialDto)
        {

            var material = await _repo.GetMaterial(id);
            if (material == null)
                return BadRequest();

            var um = await _repo.GetUnidadMedida(materialDto.UnidadMedidaId);
            material.ClaveMaterial = materialDto.ClaveMaterial;
            material.Descripcion = materialDto.Descripcion;
            material.TipoMaterialId = materialDto.TipoMaterialId;
            material.UltimaModificacion = DateTime.Now;
            material.UnidadMedida = um;

            await _repo.SaveAll();

            return NoContent();
        }

        [HttpGet("{material}/existe/{id}")]
        public async Task<IActionResult> ExisteMaterial(string material, int id)
        {
            return Ok(await _repo.ExisteMaterial(material, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _repo.GetMaterial(id);
            if (material == null)
                return NotFound();

            _repo.Delete(material);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Error al borrar material");

        }


    }
}
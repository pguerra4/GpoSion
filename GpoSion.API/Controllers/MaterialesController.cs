using System;
using System.Collections.Generic;
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
            var viajerosToReturn = _mapper.Map<IEnumerable<ViajeroForDetailDto>>(viajeros);

            return Ok(viajerosToReturn);
        }

        [Authorize(Policy = "AlmacenMateriaPrimaRole")]
        [HttpPost()]
        public async Task<IActionResult> PostMaterial(MaterialforPostDto materialDto)
        {

            var um = await _repo.GetUnidadMedida(materialDto.UnidadMedidaId);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var material = new Material { UnidadMedida = um, FechaCreacion = DateTime.Now, ClaveMaterial = materialDto.ClaveMaterial.Trim(), Descripcion = materialDto.Descripcion, TipoMaterialId = materialDto.TipoMaterialId, CreadoPorId = userId, StockMinimo = materialDto.StockMinimo };
            // _mapper.Map(materialDto, material);

            _repo.Add(material);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetMaterial", new { id = material.MaterialId }, material);

            throw new Exception("Material no guardado");
        }

        [Authorize(Policy = "AlmacenMateriaPrimaRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, MaterialForPutDto materialDto)
        {

            var material = await _repo.GetMaterial(id);
            if (material == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var um = await _repo.GetUnidadMedida(materialDto.UnidadMedidaId);
            material.ClaveMaterial = materialDto.ClaveMaterial.Trim();
            material.Descripcion = materialDto.Descripcion;
            material.TipoMaterialId = materialDto.TipoMaterialId;
            material.UltimaModificacion = DateTime.Now;
            material.UnidadMedida = um;
            material.ModificadoPorId = userId;
            material.UltimaModificacion = DateTime.Now;
            material.StockMinimo = materialDto.StockMinimo;

            await _repo.SaveAll();

            return NoContent();
        }


        [HttpGet("{material}/existe/{id}")]
        public async Task<IActionResult> ExisteMaterial(string material, int id)
        {
            return Ok(await _repo.ExisteMaterial(material, id));
        }

        [Authorize(Policy = "AlmacenMateriaPrimaRole")]
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
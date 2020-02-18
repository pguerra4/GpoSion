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
    public class ProduccionController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public ProduccionController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetProducciones([FromQuery] ProduccionParams produccionParams)
        {
            var producciones = await _repo.GetProducciones(produccionParams);
            var produccionesToReturn = _mapper.Map<IEnumerable<ProduccionForDetailDto>>(producciones);
            return Ok(produccionesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduccion(int id)
        {
            var molde = await _repo.GetMolde(id);
            var moldeToReturn = _mapper.Map<MoldeForDetailDto>(molde);

            return Ok(moldeToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostProduccion(ProduccionToCreateDto produccionToCreateDto)
        {


            var prod = _mapper.Map<Produccion>(produccionToCreateDto);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            prod.FechaCreacion = DateTime.Now;
            prod.CreadoPorId = userId;

            _repo.Add(prod);

            var moldeadora = await _repo.GetMoldeadora(prod.MoldeadoraId.Value);
            if (moldeadora == null)
                return BadRequest("No existe la moldeadora seleccionada.");

            var material = moldeadora.Material;
            if (material == null)
                return BadRequest("No hay material asociado a la moldeadora.");

            var areas = await _repo.GetAreas();

            var produccion = areas.FirstOrDefault(a => a.NombreArea.ToLower() == "producción");
            var existenciaProduccion = await _repo.GetExistenciaPorAreaMaterial(produccion.AreaId, material.MaterialId);
            if (existenciaProduccion == null)
                return BadRequest("No hay existencias del material " + material.ClaveMaterial + " en producción.");

            decimal total = 0;
            foreach (ProduccionNumeroParte pnp in prod.ProduccionNumerosParte)
            {
                var np = await _repo.GetNumeroParte(pnp.NoParte);
                total += pnp.Piezas * np.Peso;
                total += pnp.Scrap * np.Peso;
            }

            total += prod.Colada.Value + prod.Purga.Value;

            existenciaProduccion.Existencia -= total;

            var mm = new MovimientoMaterial { Fecha = prod.Fecha, Material = material, Cantidad = total, Origen = produccion, Destino = produccion, ViajeroId = null, RequerimientoMaterialMaterialId = null, RequerimientoMaterialMaterial = null, Recibo = null, FechaCreacion = DateTime.Now, CreadoPorId = userId };
            _repo.Add(mm);

            if (await _repo.SaveAll())
            {
                var prodtoReturn = _mapper.Map<ProduccionForDetailDto>(prod);
                return CreatedAtAction("GetProduccion", new { id = prod.ProduccionId }, prodtoReturn);
            }


            throw new Exception("Captura de producción no guardada");
        }



        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutMolde(int id, MoldeForPutDto moldeFP)
        // {
        //     // var molde = await _repo.GetMolde(id);
        //     // if (molde == null)
        //     //     return BadRequest();
        //     // if (molde.Id != moldeFP.Id)
        //     //     return BadRequest();


        //     // molde.ClaveMolde = moldeFP.ClaveMolde;
        //     // molde.ClienteId = moldeFP.ClienteId;
        //     // molde.UbicacionAreaId = moldeFP.UbicacionAreaId;
        //     // // molde.MaquinaMoldeadoraId = moldeFP.MaquinaMoldeadoraId;
        //     // molde.UltimaModificacion = moldeFP.UltimaModificacion;



        //     // if (await _repo.SaveAll())
        //     //     return NoContent();

        //     throw new Exception("Molde no guardado");
        // }
    }
}
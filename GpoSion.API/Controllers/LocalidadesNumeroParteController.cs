using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using GpoSion.API.Models;
using System.Security.Claims;
using System;

namespace GpoSion.API.Controllers
{


    [Authorize(Policy = "AlmacenRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesNumeroParteController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public LocalidadesNumeroParteController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }


        [HttpGet("{noParte}")]
        public async Task<IActionResult> GetLocalidadesNumeroParte(string noParte)
        {
            var localidadesNumeroParte = await _repo.GetLocalidadesNumeroParte(noParte);
            var localidadesToReturn = _mapper.Map<IEnumerable<LocalidadNumeroParteToListDto>>(localidadesNumeroParte);

            return Ok(localidadesToReturn);
        }

        [HttpGet("{localidadId}/{noParte}")]
        public async Task<IActionResult> GetLocalidadNumeroParte(int localidadId, string noParte)
        {
            var localidadNumeroParte = await _repo.GetLocalidadNumeroParte(localidadId, noParte);
            var localidadToReturn = _mapper.Map<LocalidadNumeroParteToListDto>(localidadNumeroParte);

            return Ok(localidadToReturn);
        }


        [HttpPost()]
        public async Task<IActionResult> PostLocalidadNumeroParte(LocalidadNumeroParteToEditDto lnpFP)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var lnp = await _repo.GetLocalidadNumeroParte(lnpFP.LocalidadId, lnpFP.NoParte);
            if (lnp == null)
            {
                lnp = new LocalidadNumeroParte { LocalidadId = lnpFP.LocalidadId, NoParte = lnpFP.NoParte, Existencia = lnpFP.Existencia, CreadoPorId = userId, FechaCreacion = DateTime.Now };
                _repo.Add(lnp);
            }
            else
            {
                lnp.Existencia = lnpFP.Existencia;
                lnp.UltimaModificacion = DateTime.Now;
                lnp.ModificadoPorId = userId;
            }

            var movimiento = new MovimientoProducto
            {
                NoParte = lnpFP.NoParte,
                PiezasCertificadas = (int)lnpFP.Existencia,
                Fecha = DateTime.Now,
                FechaCreacion = DateTime.Now,
                CreadoPorId = userId,
                TipoMovimiento = "Ajuste localidad existencia"
            };

            _repo.Add(movimiento);


            var ajuste = new AjusteInventarioProducto
            {
                Fecha = DateTime.Now,
                Motivo = lnpFP.Motivo,
                CreadoPorId = userId,
                ExistenciaOriginal = 0,
                ExistenciaFinal = (int)lnpFP.Existencia,
                LocalidadId = lnpFP.LocalidadId,
                NoParte = lnpFP.NoParte
            };

            _repo.Add(ajuste);



            if (await _repo.SaveAll())
            {
                var localidad = _mapper.Map<LocalidadNumeroParteToListDto>(lnp);
                return CreatedAtAction("GetLocalidadesNumeroParte", new { noParte = lnp.NoParte }, localidad);
            }


            throw new Exception("Localidad no guardada");
        }


        [HttpPut("{localidadId}/{noParte}")]
        public async Task<IActionResult> PutLocalidadNumeroParte(int localidadId, string noParte, LocalidadNumeroParteToEditDto lnpFP)
        {
            var lnp = await _repo.GetLocalidadNumeroParte(localidadId, noParte);
            if (lnp == null)
                return NotFound();


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var movimiento = new MovimientoProducto
            {
                NoParte = lnp.NoParte,
                PiezasCertificadas = (int)lnpFP.Existencia,
                Fecha = DateTime.Now,
                FechaCreacion = DateTime.Now,
                CreadoPorId = userId,
                TipoMovimiento = "Ajuste localidad existencia"
            };

            _repo.Add(movimiento);


            var ajuste = new AjusteInventarioProducto
            {
                Fecha = DateTime.Now,
                Motivo = lnpFP.Motivo,
                CreadoPorId = userId,
                ExistenciaOriginal = (int)lnp.Existencia,
                ExistenciaFinal = (int)lnpFP.Existencia,
                LocalidadId = lnpFP.LocalidadId,
                NoParte = lnpFP.NoParte
            };

            _repo.Add(ajuste);

            lnp.Existencia = lnpFP.Existencia;
            lnp.ModificadoPorId = userId;
            lnp.UltimaModificacion = DateTime.Now;

            await _repo.SaveAll();

            return NoContent();
        }

    }
}
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
    [Authorize(Policy = "AlmacenRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmbarquesController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public EmbarquesController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetEmbarques([FromQuery] EmbarqueParams embarqueParams)
        {
            var embarques = await _repo.GetEmbarques(embarqueParams);
            var embarquesToReturn = _mapper.Map<IEnumerable<EmbarqueToListDto>>(embarques);

            return Ok(embarquesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmbarque(int Id)
        {
            var embarque = await _repo.GetEmbarque(Id);
            var embarqueToReturn = _mapper.Map<EmbarqueToListDto>(embarque);

            return Ok(embarqueToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostEmbarque(EmbarqueToCreateDto embarqueToCreate)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var embarque = _mapper.Map<Embarque>(embarqueToCreate);
            embarque.Fecha = embarque.Fecha.ToLocalTime();
            embarque.FechaCreacion = DateTime.Now;
            embarque.CreadoPorId = userId;

            _repo.Add(embarque);
            MovimientoProducto movimiento;

            foreach (var de in embarque.DetallesEmbarque)
            {

                de.FechaCreacion = DateTime.Now;
                de.CreadoPorId = userId;

                movimiento = new MovimientoProducto
                {
                    NoParte = de.NoParte,
                    Fecha = embarque.Fecha,
                    FechaCreacion = DateTime.Now,
                    CreadoPorId = userId,
                    Cajas = de.Cajas,
                    PiezasXCaja = de.PiezasXCaja,
                    TipoMovimiento = "Embarque",
                    DetalleEmbarqueId = de.DetalleEmbarqueId
                };
                if (!embarque.Rechazadas)
                {
                    movimiento.PiezasCertificadas = de.Entregadas;
                }
                else
                {
                    movimiento.PiezasRechazadas = de.Entregadas;
                }

                _repo.Add(movimiento);




                var existencia = await _repo.GetExistenciaProducto(de.NoParte);
                if (existencia == null)
                    return BadRequest("La solicitud para el No. Parte " + de.NoParte + " no tiene existencias en almacen.");

                if (!embarque.Rechazadas)
                {
                    if (existencia.PiezasCertificadas < de.Entregadas)
                        return BadRequest("La solicitud para el No. Parte " + de.NoParte + " excede las existencias en almacen.");

                    existencia.PiezasCertificadas -= de.Entregadas;
                    existencia.UltimaModificacion = DateTime.Now;
                    existencia.ModificadoPorId = userId;


                    var localidadesNumeroParte = await _repo.GetLocalidadesNumeroParte(de.NoParte);
                    var localidadesNumeroParteArray = localidadesNumeroParte.OrderBy(npl => npl.UltimaModificacion.HasValue ? npl.UltimaModificacion : npl.FechaCreacion).ThenBy(npl => npl.Existencia).ToArray();

                    decimal total = 0;
                    var listo = false;
                    var localidadesCount = localidadesNumeroParte.Count();
                    var indice = 0;
                    while (!listo && indice < localidadesCount)
                    {
                        if (localidadesNumeroParteArray[indice].Existencia >= (de.Entregadas - total))
                        {
                            localidadesNumeroParteArray[indice].Existencia -= (de.Entregadas - total);
                            listo = true;

                        }
                        else
                        {
                            total += localidadesNumeroParteArray[indice].Existencia;
                            localidadesNumeroParteArray[indice].Existencia = 0;
                        }
                        indice++;
                    }

                }
                else
                {
                    if (existencia.PiezasRechazadas < de.Entregadas)
                        return BadRequest("La solicitud para el No. Parte " + de.NoParte + " excede las piezas rechazadas en almacen.");

                    existencia.PiezasRechazadas -= de.Entregadas;
                    existencia.UltimaModificacion = DateTime.Now;
                    existencia.ModificadoPorId = userId;


                }


                var orden = await _repo.GetOrdenCompra(de.NoOrden.Value);
                var ocd = orden.NumerosParte.FirstOrDefault(np => np.NoParte == de.NoParte);
                if (ocd == null)
                    return BadRequest("No existe orden de compra para el No. Parte " + de.NoParte);

                if (!embarque.Rechazadas)
                {
                    if (ocd.PiezasAutorizadas > 0 && ocd.PiezasAutorizadas < (ocd.PiezasSurtidas + de.Entregadas))
                        return BadRequest("La orden de compra " + de.NoOrden + " para el No. Parte " + de.NoParte + " excede las piezas autorizadas.");
                    if (ocd.FechaFin.HasValue && ocd.FechaFin.Value.Date < DateTime.Now.Date)
                        return BadRequest("La orden de compra " + de.NoOrden + " para el No. Parte " + de.NoParte + " venció el " + ocd.FechaFin.Value.ToShortDateString());

                    ocd.PiezasSurtidas += de.Entregadas;
                    ocd.UltimaModificacion = DateTime.Now;
                    ocd.ModificadoPorId = userId;
                }

            }


            if (await _repo.SaveAll())
            {
                var embarqueToReturn = _mapper.Map<EmbarqueToListDto>(embarque);
                return CreatedAtAction("GetEmbarque", new { id = embarque.EmbarqueId }, embarqueToReturn);
            }


            throw new Exception("Embarque no guardado");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmbarque(int id, EmbarqueToEditDto embarqueToEdit)
        {
            var embarque = await _repo.GetEmbarque(id);
            if (embarque == null)
                return NotFound();
            if (embarque.EmbarqueId != embarqueToEdit.EmbarqueId)
                return BadRequest("Ids no coinciden");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);




            _mapper.Map(embarqueToEdit, embarque);
            embarque.ModificadoPorId = userId;
            embarque.UltimaModificacion = DateTime.Now;

            await _repo.SaveAll();
            return NoContent();


        }


        [HttpGet("{id}/Existe")]
        public async Task<IActionResult> ExisteFolioEmbarque(int id)
        {

            return Ok(await _repo.ExisteFolioEmbarque(id));

        }
    }
}
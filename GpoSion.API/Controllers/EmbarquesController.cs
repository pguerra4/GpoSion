using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Helpers;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{
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

            var embarque = _mapper.Map<Embarque>(embarqueToCreate);
            embarque.Fecha = embarque.Fecha.ToLocalTime();
            _repo.Add(embarque);
            MovimientoProducto movimiento;

            foreach (var de in embarque.DetallesEmbarque)
            {

                movimiento = new MovimientoProducto
                {
                    NoParte = de.NoParte,
                    Fecha = embarque.Fecha,
                    FechaCreacion = DateTime.Now,
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
                }
                else
                {
                    if (existencia.PiezasRechazadas < de.Entregadas)
                        return BadRequest("La solicitud para el No. Parte " + de.NoParte + " excede las piezas rechazadas en almacen.");

                    existencia.PiezasRechazadas -= de.Entregadas;
                    existencia.UltimaModificacion = DateTime.Now;
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
        public async Task<IActionResult> PutMovimientoProducto(int id, MovimientoProductoForPutDto movimientoFP)
        {
            var movimiento = await _repo.GetMovimientoProducto(id);
            if (movimiento == null)
                return NotFound();
            if (movimiento.MovimientoProductoId != movimientoFP.MovimientoProductoId)
                return BadRequest("Ids no coinciden");

            if (movimientoFP.PiezasRechazadas > 0)
            {
                var piezasRechazadas = 0;
                var np = await _repo.GetNumeroParte(movimientoFP.NoParte);
                switch (movimientoFP.UnidadMedidaIdRechazadas)
                {
                    case 1:

                        piezasRechazadas = (int)Math.Floor(movimientoFP.PiezasRechazadas / np.Peso);
                        movimientoFP.PiezasRechazadas = piezasRechazadas;
                        break;
                    case 2:

                        piezasRechazadas = (int)Math.Floor((movimientoFP.PiezasRechazadas * (decimal)2.2046) / np.Peso);
                        movimientoFP.PiezasRechazadas = piezasRechazadas;
                        break;
                    default:
                        break;

                }
            }


            var existencia = await _repo.GetExistenciaProducto(movimientoFP.NoParte);
            if (movimiento.NoParte != movimientoFP.NoParte)
            {
                var otraExistencia = await _repo.GetExistenciaProducto(movimiento.NoParte);
                if (otraExistencia != null)
                {
                    otraExistencia.PiezasCertificadas -= movimiento.PiezasCertificadas;
                    otraExistencia.PiezasRechazadas -= movimiento.PiezasRechazadas;
                    otraExistencia.UltimaModificacion = DateTime.Now;
                }
                if (existencia != null)
                {
                    existencia.PiezasCertificadas += movimientoFP.PiezasCertificadas;
                    existencia.PiezasRechazadas += (int)movimientoFP.PiezasRechazadas;
                    existencia.UltimaModificacion = DateTime.Now;
                }

            }
            else
            {
                if (existencia != null)
                {
                    existencia.PiezasCertificadas += (movimientoFP.PiezasCertificadas - movimiento.PiezasCertificadas);
                    existencia.PiezasRechazadas += ((int)movimientoFP.PiezasRechazadas - movimiento.PiezasRechazadas);
                    existencia.UltimaModificacion = DateTime.Now;
                }
                else
                {
                    existencia = new ExistenciaProducto { NoParte = movimientoFP.NoParte, PiezasCertificadas = movimientoFP.PiezasCertificadas, PiezasRechazadas = (int)movimientoFP.PiezasRechazadas, UltimaModificacion = DateTime.Now };
                    _repo.Add(existencia);
                }
            }




            movimientoFP.TipoMovimiento = "Entrada Almacen";
            _mapper.Map(movimientoFP, movimiento);

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
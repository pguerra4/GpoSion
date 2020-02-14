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
    public class DetallesEmbarqueController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public DetallesEmbarqueController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleEmbarque(int Id)
        {
            var detalleEmbarque = await _repo.GetDetalleEmbarque(Id);
            var detalleEmbarqueToReturn = _mapper.Map<DetalleEmbarqueToListDto>(detalleEmbarque);

            return Ok(detalleEmbarqueToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostDetalleEmbarque(DetalleEmbarqueToCreateDto detalleEmbarqueToCreate)
        {
            var embarque = await _repo.GetEmbarque(detalleEmbarqueToCreate.EmbarqueId);
            if (embarque == null)
                return BadRequest("Embarque inexistente");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var detalleEmbarque = _mapper.Map<DetalleEmbarque>(detalleEmbarqueToCreate);
            detalleEmbarque.FechaCreacion = DateTime.Now;
            detalleEmbarque.CreadoPorId = userId;



            embarque.DetallesEmbarque.Add(detalleEmbarque);

            MovimientoProducto movimiento;



            movimiento = new MovimientoProducto
            {
                NoParte = detalleEmbarque.NoParte,
                Fecha = DateTime.Now,
                FechaCreacion = DateTime.Now,
                CreadoPorId = userId,
                Cajas = detalleEmbarque.Cajas,
                PiezasXCaja = detalleEmbarque.PiezasXCaja,
                TipoMovimiento = "Agregado Detalle Embarque",
                DetalleEmbarque = detalleEmbarque
            };
            if (!embarque.Rechazadas)
            {
                movimiento.PiezasCertificadas = detalleEmbarque.Entregadas;
            }
            else
            {
                movimiento.PiezasRechazadas = detalleEmbarque.Entregadas;
            }

            _repo.Add(movimiento);

            var existencia = await _repo.GetExistenciaProducto(detalleEmbarque.NoParte);
            if (existencia == null)
                return BadRequest("La solicitud para el No. Parte " + detalleEmbarque.NoParte + " no tiene existencias en almacen.");

            if (!embarque.Rechazadas)
            {
                if (existencia.PiezasCertificadas < detalleEmbarque.Entregadas)
                    return BadRequest("La solicitud para el No. Parte " + detalleEmbarque.NoParte + " excede las existencias en almacen.");

                existencia.PiezasCertificadas -= detalleEmbarque.Entregadas;
                existencia.UltimaModificacion = DateTime.Now;
                existencia.ModificadoPorId = userId;

                var localidadesNumeroParte = await _repo.GetLocalidadesNumeroParte(detalleEmbarque.NoParte);
                var localidadesNumeroParteArray = localidadesNumeroParte.OrderBy(npl => npl.UltimaModificacion.HasValue ? npl.UltimaModificacion : npl.FechaCreacion).ThenBy(npl => npl.Existencia).ToArray();

                decimal total = 0;
                var listo = false;
                var localidadesCount = localidadesNumeroParte.Count();
                var indice = 0;
                while (!listo && indice < localidadesCount)
                {
                    if (localidadesNumeroParteArray[indice].Existencia >= (detalleEmbarque.Entregadas - total))
                    {
                        localidadesNumeroParteArray[indice].Existencia -= (detalleEmbarque.Entregadas - total);
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
                if (existencia.PiezasRechazadas < detalleEmbarque.Entregadas)
                    return BadRequest("La solicitud para el No. Parte " + detalleEmbarque.NoParte + " excede las piezas rechazadas en almacen.");

                existencia.PiezasRechazadas -= detalleEmbarque.Entregadas;
                existencia.UltimaModificacion = DateTime.Now;
                existencia.ModificadoPorId = userId;
            }


            var orden = await _repo.GetOrdenCompra(detalleEmbarque.NoOrden.Value);
            var ocd = orden.NumerosParte.FirstOrDefault(np => np.NoParte == detalleEmbarque.NoParte);
            if (ocd == null)
                return BadRequest("No existe orden de compra para el No. Parte " + detalleEmbarque.NoParte);

            if (!embarque.Rechazadas)
            {
                if (ocd.PiezasAutorizadas > 0 && ocd.PiezasAutorizadas < (ocd.PiezasSurtidas + detalleEmbarque.Entregadas))
                    return BadRequest("La orden de compra " + detalleEmbarque.NoOrden + " para el No. Parte " + detalleEmbarque.NoParte + " excede las piezas autorizadas.");
                if (ocd.FechaFin.HasValue && ocd.FechaFin.Value.Date < DateTime.Now.Date)
                    return BadRequest("La orden de compra " + detalleEmbarque.NoOrden + " para el No. Parte " + detalleEmbarque.NoParte + " venció el " + ocd.FechaFin.Value.ToShortDateString());

                ocd.PiezasSurtidas += detalleEmbarque.Entregadas;
                ocd.UltimaModificacion = DateTime.Now;
                ocd.ModificadoPorId = userId;
            }




            if (await _repo.SaveAll())
            {
                var detalleEmbarqueToReturn = _mapper.Map<DetalleEmbarqueToListDto>(detalleEmbarque);
                return CreatedAtAction("GetDetalleEmbarque", new { id = detalleEmbarque.DetalleEmbarqueId }, detalleEmbarqueToReturn);
            }


            throw new Exception("detalle embarque no guardado");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleEmbarque(int id, DetalleEmbarqueToListDto detalleEmbarqueToEdit)
        {
            if (id != detalleEmbarqueToEdit.DetalleEmbarqueId)
                return BadRequest("Ids no coinciden.");


            var embarque = await _repo.GetEmbarque(detalleEmbarqueToEdit.EmbarqueId);//*******

            if (embarque == null)
                return BadRequest("Embarque inexistente");

            var detalleEmbarque = await _repo.GetDetalleEmbarque(id);

            if (detalleEmbarque == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (detalleEmbarque.NoParte != detalleEmbarqueToEdit.NoParte)
            {
                var existenciaOriginal = await _repo.GetExistenciaProducto(detalleEmbarque.NoParte);
                if (existenciaOriginal != null)
                {
                    if (!embarque.Rechazadas)
                    {
                        existenciaOriginal.PiezasCertificadas += detalleEmbarque.Entregadas;
                        existenciaOriginal.UltimaModificacion = DateTime.Now;
                        existenciaOriginal.ModificadoPorId = userId;

                        var localidadNumeroParteOriginal = (await _repo.GetLocalidadesNumeroParte(detalleEmbarque.NoParte)).OrderByDescending(npl => npl.UltimaModificacion.HasValue ? npl.UltimaModificacion : npl.FechaCreacion).ThenBy(npl => npl.Existencia).FirstOrDefault();
                        if (localidadNumeroParteOriginal != null)
                        {
                            localidadNumeroParteOriginal.Existencia += detalleEmbarque.Entregadas;
                        }

                    }
                    else
                    {
                        existenciaOriginal.PiezasRechazadas += detalleEmbarque.Entregadas;
                        existenciaOriginal.UltimaModificacion = DateTime.Now;
                        existenciaOriginal.ModificadoPorId = userId;
                    }
                }


                var existencia = await _repo.GetExistenciaProducto(detalleEmbarqueToEdit.NoParte);
                if (existencia == null)
                    return BadRequest("La solicitud para el No. Parte " + detalleEmbarqueToEdit.NoParte + " no tiene existencias en almacen.");

                if (!embarque.Rechazadas)
                {
                    if (existencia.PiezasCertificadas < detalleEmbarqueToEdit.Entregadas)
                        return BadRequest("La solicitud para el No. Parte " + detalleEmbarqueToEdit.NoParte + " excede las existencias en almacen.");

                    existencia.PiezasCertificadas -= detalleEmbarqueToEdit.Entregadas;
                    existencia.UltimaModificacion = DateTime.Now;
                    existencia.ModificadoPorId = userId;

                    var localidadNumeroParte = (await _repo.GetLocalidadesNumeroParte(detalleEmbarqueToEdit.NoParte)).Where(npl => npl.Existencia >= detalleEmbarqueToEdit.Entregadas).OrderByDescending(npl => npl.UltimaModificacion.HasValue ? npl.UltimaModificacion : npl.FechaCreacion).ThenBy(npl => npl.Existencia).FirstOrDefault();
                    if (localidadNumeroParte != null)
                    {
                        localidadNumeroParte.Existencia -= detalleEmbarqueToEdit.Entregadas;
                    }

                }
                else
                {
                    if (existencia.PiezasRechazadas < detalleEmbarqueToEdit.Entregadas)
                        return BadRequest("La solicitud para el No. Parte " + detalleEmbarqueToEdit.NoParte + " excede las piezas rechazadas en almacen.");

                    existencia.PiezasRechazadas -= detalleEmbarqueToEdit.Entregadas;
                    existencia.UltimaModificacion = DateTime.Now;
                    existencia.ModificadoPorId = userId;
                }


            }
            else
            {
                var diferenciaExistencia = detalleEmbarqueToEdit.Entregadas - detalleEmbarque.Entregadas;
                var existencia = await _repo.GetExistenciaProducto(detalleEmbarqueToEdit.NoParte);
                if (existencia == null)
                    return BadRequest("La solicitud para el No. Parte " + detalleEmbarqueToEdit.NoParte + " no tiene existencias en almacen.");

                if (!embarque.Rechazadas)
                {
                    if ((existencia.PiezasCertificadas + detalleEmbarque.Entregadas) < detalleEmbarqueToEdit.Entregadas)
                        return BadRequest("La solicitud para el No. Parte " + detalleEmbarqueToEdit.NoParte + " excede las existencias en almacen.");

                    existencia.PiezasCertificadas -= diferenciaExistencia;
                    existencia.UltimaModificacion = DateTime.Now;
                    existencia.ModificadoPorId = userId;

                    var localidadNumeroParte = (await _repo.GetLocalidadesNumeroParte(detalleEmbarqueToEdit.NoParte)).Where(npl => (npl.Existencia - diferenciaExistencia) >= 0).OrderByDescending(npl => npl.UltimaModificacion.HasValue ? npl.UltimaModificacion : npl.FechaCreacion).ThenBy(npl => npl.Existencia).FirstOrDefault();
                    if (localidadNumeroParte != null)
                    {
                        localidadNumeroParte.Existencia -= diferenciaExistencia;
                    }

                }
                else
                {
                    if ((existencia.PiezasRechazadas + detalleEmbarque.Entregadas) < detalleEmbarqueToEdit.Entregadas)
                        return BadRequest("La solicitud para el No. Parte " + detalleEmbarqueToEdit.NoParte + " excede las piezas rechazadas en almacen.");

                    existencia.PiezasRechazadas -= diferenciaExistencia;
                    existencia.UltimaModificacion = DateTime.Now;
                    existencia.ModificadoPorId = userId;
                }


            }

            var diferencia = detalleEmbarqueToEdit.Entregadas - detalleEmbarque.Entregadas;

            if (detalleEmbarque.NoOrden != detalleEmbarqueToEdit.NoOrden)
            {
                var ordenOriginal = await _repo.GetOrdenCompra(detalleEmbarque.NoOrden.Value);
                var ocdOriginal = ordenOriginal.NumerosParte.FirstOrDefault(np => np.NoParte == detalleEmbarque.NoParte);

                if (!embarque.Rechazadas)
                {
                    if (ocdOriginal == null)
                        return BadRequest("No existe orden de compra para el No. Parte " + detalleEmbarque.NoParte);

                    ocdOriginal.PiezasSurtidas -= detalleEmbarque.Entregadas;


                }

                diferencia = detalleEmbarqueToEdit.Entregadas;
            }

            var orden = await _repo.GetOrdenCompra(detalleEmbarqueToEdit.NoOrden.Value);
            var ocd = orden.NumerosParte.FirstOrDefault(np => np.NoParte == detalleEmbarqueToEdit.NoParte);


            if (ocd == null)
                return BadRequest("No existe orden de compra para el No. Parte " + detalleEmbarqueToEdit.NoParte);

            if (!embarque.Rechazadas)
            {
                if (ocd.PiezasAutorizadas > 0 && ocd.PiezasAutorizadas < (ocd.PiezasSurtidas - diferencia))
                    return BadRequest("La orden de compra " + detalleEmbarqueToEdit.NoOrden + " para el No. Parte " + detalleEmbarqueToEdit.NoParte + " excede las piezas autorizadas.");
                if (ocd.FechaFin.HasValue && ocd.FechaFin.Value.Date < DateTime.Now.Date)
                    return BadRequest("La orden de compra " + detalleEmbarqueToEdit.NoOrden + " para el No. Parte " + detalleEmbarqueToEdit.NoParte + " venció el " + ocd.FechaFin.Value.ToShortDateString());

                ocd.PiezasSurtidas += diferencia;
                ocd.UltimaModificacion = DateTime.Now;
                ocd.ModificadoPorId = userId;
            }


            MovimientoProducto movimiento;



            movimiento = new MovimientoProducto
            {
                NoParte = detalleEmbarqueToEdit.NoParte,
                Fecha = DateTime.Now,
                FechaCreacion = DateTime.Now,
                CreadoPorId = userId,
                Cajas = detalleEmbarqueToEdit.Cajas,
                PiezasXCaja = detalleEmbarqueToEdit.PiezasXCaja,
                TipoMovimiento = "Modificación Detalle Embarque",
                DetalleEmbarqueId = detalleEmbarqueToEdit.DetalleEmbarqueId
            };
            if (!embarque.Rechazadas)
            {
                movimiento.PiezasCertificadas = detalleEmbarqueToEdit.Entregadas;
            }
            else
            {
                movimiento.PiezasRechazadas = detalleEmbarqueToEdit.Entregadas;
            }

            _repo.Add(movimiento);



            _mapper.Map(detalleEmbarqueToEdit, detalleEmbarque);
            detalleEmbarque.UltimaModificacion = DateTime.Now;
            detalleEmbarque.ModificadoPorId = userId;



            if (await _repo.SaveAll())
            {
                var detalleEmbarqueToReturn = _mapper.Map<DetalleEmbarqueToListDto>(detalleEmbarque);
                return NoContent();
            }


            throw new Exception("detalle embarque no guardado");


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleEmbarque(int id)
        {



            var detalleFromRepo = await _repo.GetDetalleEmbarque(id);

            if (detalleFromRepo == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var existenciaProducto = await _repo.GetExistenciaProducto(detalleFromRepo.NoParte);
            if (existenciaProducto == null)
            {
                existenciaProducto = new ExistenciaProducto
                {
                    NoParte = detalleFromRepo.NoParte,
                    FechaCreacion = DateTime.Now,
                    CreadoPorId = userId
                };

                if (detalleFromRepo.Embarque.Rechazadas)
                {
                    existenciaProducto.PiezasRechazadas += detalleFromRepo.Entregadas;
                }
                else
                {
                    existenciaProducto.PiezasCertificadas += detalleFromRepo.Entregadas;
                }
                _repo.Add(existenciaProducto);
            }
            else
            {
                if (detalleFromRepo.Embarque.Rechazadas)
                {
                    existenciaProducto.PiezasRechazadas += detalleFromRepo.Entregadas;
                }
                else
                {
                    existenciaProducto.PiezasCertificadas += detalleFromRepo.Entregadas;
                }
                existenciaProducto.UltimaModificacion = DateTime.Now;
                existenciaProducto.ModificadoPorId = userId;
            }

            if (!detalleFromRepo.Embarque.Rechazadas)
            {
                detalleFromRepo.OrdenCompra.NumerosParte.FirstOrDefault(np => np.NoParte == detalleFromRepo.NoParte).PiezasSurtidas -= detalleFromRepo.Entregadas;
            }

            var localidadesNumeroParte = await _repo.GetLocalidadesNumeroParte(detalleFromRepo.NoParte);
            if (localidadesNumeroParte != null)
            {
                var localidadNumeroParte = localidadesNumeroParte.OrderByDescending(npl => npl.UltimaModificacion.HasValue ? npl.UltimaModificacion : npl.FechaCreacion).ThenBy(npl => npl.Existencia).FirstOrDefault();

                if (localidadNumeroParte != null)
                {
                    localidadNumeroParte.Existencia += detalleFromRepo.Entregadas;
                }
            }


            foreach (var mp in detalleFromRepo.Movimientos)
            {
                _repo.Delete(mp);
            }

            _repo.Delete(detalleFromRepo);



            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Fallo el borrado del detalle de embarque " + detalleFromRepo.DetalleEmbarqueId + " probablemente ya este asignada a movimientos.");
        }

        [HttpGet("{id}/Existe")]
        public async Task<IActionResult> ExisteFolioEmbarque(int id)
        {

            return Ok(await _repo.ExisteFolioEmbarque(id));

        }
    }
}
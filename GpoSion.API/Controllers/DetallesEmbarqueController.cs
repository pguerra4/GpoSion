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
    [Authorize(Policy = "AlmacenProductoRole")]
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
                DetalleEmbarque = detalleEmbarque,
                LocalidadId = detalleEmbarque.LocalidadId
            };
            if (!embarque.Rechazadas)
            {
                movimiento.PiezasCertificadas = detalleEmbarque.Entregadas;
            }
            else
            {
                movimiento.PiezasRechazadas = detalleEmbarque.Entregadas;
            }



            var existencia = await _repo.GetExistenciaProducto(detalleEmbarque.NoParte);
            if (existencia == null)
                return BadRequest("La solicitud para el No. Parte " + detalleEmbarque.NoParte + " no tiene existencias en almacen.");

            if (!embarque.Rechazadas)
            {
                if (existencia.PiezasCertificadas < detalleEmbarque.Entregadas)
                    return BadRequest("La solicitud para el No. Parte " + detalleEmbarque.NoParte + " excede las existencias en almacen.");

                movimiento.ExistenciaAlmacenInicial = existencia.PiezasCertificadas;
                existencia.PiezasCertificadas -= detalleEmbarque.Entregadas;
                existencia.UltimaModificacion = DateTime.Now;
                existencia.ModificadoPorId = userId;
                movimiento.ExistenciaAlmacenFinal = existencia.PiezasCertificadas;

                var localidadNumeroParte = await _repo.GetLocalidadNumeroParte(detalleEmbarque.LocalidadId.Value, detalleEmbarque.NoParte);
                localidadNumeroParte.Existencia -= detalleEmbarque.Entregadas;
                localidadNumeroParte.ModificadoPorId = userId;
                localidadNumeroParte.UltimaModificacion = DateTime.Now;

            }
            else
            {
                if (existencia.PiezasRechazadas < detalleEmbarque.Entregadas)
                    return BadRequest("La solicitud para el No. Parte " + detalleEmbarque.NoParte + " excede las piezas rechazadas en almacen.");


                existencia.PiezasRechazadas -= detalleEmbarque.Entregadas;
                existencia.UltimaModificacion = DateTime.Now;
                existencia.ModificadoPorId = userId;
            }

            _repo.Add(movimiento);


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


            _repo.Add(detalleEmbarque);

            if (await _repo.SaveAll())
            {
                var localidad = await _repo.GetLocalidad(detalleEmbarque.LocalidadId.Value);
                detalleEmbarque.Localidad = localidad;
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
                DetalleEmbarqueId = detalleEmbarqueToEdit.DetalleEmbarqueId,
                LocalidadId = detalleEmbarqueToEdit.LocalidadId
            };
            if (!embarque.Rechazadas)
            {
                movimiento.PiezasCertificadas = detalleEmbarqueToEdit.Entregadas;
            }
            else
            {
                movimiento.PiezasRechazadas = detalleEmbarqueToEdit.Entregadas;
            }




            if (detalleEmbarque.NoParte != detalleEmbarqueToEdit.NoParte)
            {
                MovimientoProducto newMovimiento;

                newMovimiento = new MovimientoProducto
                {
                    NoParte = detalleEmbarque.NoParte,
                    Fecha = DateTime.Now,
                    FechaCreacion = DateTime.Now,
                    CreadoPorId = userId,
                    Cajas = detalleEmbarqueToEdit.Cajas,
                    PiezasXCaja = detalleEmbarqueToEdit.PiezasXCaja,
                    TipoMovimiento = "Modificación Detalle Embarque con cambio de No. Parte",
                    DetalleEmbarqueId = detalleEmbarque.DetalleEmbarqueId,
                    LocalidadId = detalleEmbarque.LocalidadId
                };
                var existenciaOriginal = await _repo.GetExistenciaProducto(detalleEmbarque.NoParte);
                if (existenciaOriginal != null)
                {
                    if (!embarque.Rechazadas)
                    {
                        newMovimiento.ExistenciaAlmacenInicial = existenciaOriginal.PiezasCertificadas;
                        existenciaOriginal.PiezasCertificadas += detalleEmbarque.Entregadas;
                        existenciaOriginal.UltimaModificacion = DateTime.Now;
                        existenciaOriginal.ModificadoPorId = userId;
                        newMovimiento.ExistenciaAlmacenFinal = existenciaOriginal.PiezasCertificadas;

                        if (detalleEmbarque.LocalidadId.HasValue)
                        {
                            var localidadNumeroParteOriginal = await _repo.GetLocalidadNumeroParte(detalleEmbarque.LocalidadId.Value, detalleEmbarque.NoParte);
                            if (localidadNumeroParteOriginal != null)
                            {
                                localidadNumeroParteOriginal.Existencia += detalleEmbarque.Entregadas;
                                localidadNumeroParteOriginal.ModificadoPorId = userId;
                                localidadNumeroParteOriginal.UltimaModificacion = DateTime.Now;
                            }
                        }


                    }
                    else
                    {
                        existenciaOriginal.PiezasRechazadas += detalleEmbarque.Entregadas;
                        existenciaOriginal.UltimaModificacion = DateTime.Now;
                        existenciaOriginal.ModificadoPorId = userId;
                    }
                }

                _repo.Add(newMovimiento);

                var existencia = await _repo.GetExistenciaProducto(detalleEmbarqueToEdit.NoParte);
                if (existencia == null)
                    return BadRequest("La solicitud para el No. Parte " + detalleEmbarqueToEdit.NoParte + " no tiene existencias en almacen.");

                if (!embarque.Rechazadas)
                {
                    if (existencia.PiezasCertificadas < detalleEmbarqueToEdit.Entregadas)
                        return BadRequest("La solicitud para el No. Parte " + detalleEmbarqueToEdit.NoParte + " excede las existencias en almacen.");

                    movimiento.ExistenciaAlmacenInicial = existencia.PiezasCertificadas;
                    existencia.PiezasCertificadas -= detalleEmbarqueToEdit.Entregadas;
                    existencia.UltimaModificacion = DateTime.Now;
                    existencia.ModificadoPorId = userId;
                    movimiento.ExistenciaAlmacenFinal = existencia.PiezasCertificadas;

                    var localidadNumeroParte = await _repo.GetLocalidadNumeroParte(detalleEmbarqueToEdit.LocalidadId.Value, detalleEmbarqueToEdit.NoParte);
                    if (localidadNumeroParte != null)
                    {
                        localidadNumeroParte.Existencia -= detalleEmbarqueToEdit.Entregadas;
                        localidadNumeroParte.ModificadoPorId = userId;
                        localidadNumeroParte.UltimaModificacion = DateTime.Now;
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

                    movimiento.ExistenciaAlmacenInicial = existencia.PiezasCertificadas;
                    existencia.PiezasCertificadas -= diferenciaExistencia;
                    existencia.UltimaModificacion = DateTime.Now;
                    existencia.ModificadoPorId = userId;
                    movimiento.ExistenciaAlmacenFinal = existencia.PiezasCertificadas;

                    var localidadNumeroParte = await _repo.GetLocalidadNumeroParte(detalleEmbarqueToEdit.LocalidadId.Value, detalleEmbarqueToEdit.NoParte);
                    if (localidadNumeroParte != null)
                    {
                        localidadNumeroParte.Existencia -= diferenciaExistencia;
                        localidadNumeroParte.ModificadoPorId = userId;
                        localidadNumeroParte.UltimaModificacion = DateTime.Now;
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


            _repo.Add(movimiento);

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


            MovimientoProducto newMovimiento;

            newMovimiento = new MovimientoProducto
            {
                NoParte = detalleFromRepo.NoParte,
                Fecha = DateTime.Now,
                FechaCreacion = DateTime.Now,
                CreadoPorId = userId,
                Cajas = detalleFromRepo.Cajas,
                PiezasXCaja = detalleFromRepo.PiezasXCaja,
                TipoMovimiento = "Borrado de detalle de embarque",
                DetalleEmbarqueId = null,
                LocalidadId = detalleFromRepo.LocalidadId
            };

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
                    newMovimiento.ExistenciaAlmacenInicial = existenciaProducto.PiezasCertificadas;
                    existenciaProducto.PiezasCertificadas += detalleFromRepo.Entregadas;
                    newMovimiento.ExistenciaAlmacenFinal = existenciaProducto.PiezasCertificadas;
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
                    newMovimiento.ExistenciaAlmacenInicial = existenciaProducto.PiezasCertificadas;
                    existenciaProducto.PiezasCertificadas += detalleFromRepo.Entregadas;
                    newMovimiento.ExistenciaAlmacenFinal = existenciaProducto.PiezasCertificadas;
                }
                existenciaProducto.UltimaModificacion = DateTime.Now;
                existenciaProducto.ModificadoPorId = userId;
            }

            if (!detalleFromRepo.Embarque.Rechazadas)
            {
                detalleFromRepo.OrdenCompra.NumerosParte.FirstOrDefault(np => np.NoParte == detalleFromRepo.NoParte).PiezasSurtidas -= detalleFromRepo.Entregadas;
            }

            if (detalleFromRepo.LocalidadId.HasValue)
            {
                var localidadNumeroParte = await _repo.GetLocalidadNumeroParte(detalleFromRepo.LocalidadId.Value, detalleFromRepo.NoParte);
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
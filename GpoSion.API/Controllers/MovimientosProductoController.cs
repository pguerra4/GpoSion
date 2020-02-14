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
    [Authorize(Policy = "ProduccionAlmacen")]
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosProductoController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public MovimientosProductoController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetMovimientosProducto([FromQuery] MovimientoProductoParams movimientoParams)
        {
            var movimientos = await _repo.GetMovimientosProducto(movimientoParams);
            var movimientosToReturn = _mapper.Map<ICollection<MovimientoProductoToListDto>>(movimientos);
            return Ok(movimientosToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovimientoProducto(int Id)
        {
            var movimiento = await _repo.GetMovimientoProducto(Id);
            var movimientoToReturn = _mapper.Map<MovimientoProductoToListDto>(movimiento);

            return Ok(movimientoToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostMovimientoProducto(MovimientoProductoToCreateDto movimientoToCreate)
        {

            movimientoToCreate.TipoMovimiento = "Entrada Almacen";
            if (movimientoToCreate.PiezasRechazadas > 0)
            {
                var piezasRechazadas = 0;
                var np = await _repo.GetNumeroParte(movimientoToCreate.NoParte);
                switch (movimientoToCreate.UnidadMedidaIdRechazadas)
                {
                    case 1:

                        piezasRechazadas = (int)Math.Floor(movimientoToCreate.PiezasRechazadas / np.Peso);
                        movimientoToCreate.PiezasRechazadas = piezasRechazadas;
                        break;
                    case 2:

                        piezasRechazadas = (int)Math.Floor((movimientoToCreate.PiezasRechazadas * (decimal)2.2046) / np.Peso);
                        movimientoToCreate.PiezasRechazadas = piezasRechazadas;
                        break;
                    default:
                        break;

                }
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var movimientoProducto = _mapper.Map<MovimientoProducto>(movimientoToCreate);
            movimientoProducto.FechaCreacion = DateTime.Now;
            movimientoProducto.CreadoPorId = userId;

            _repo.Add(movimientoProducto);

            var existencia = await _repo.GetExistenciaProducto(movimientoToCreate.NoParte);
            if (existencia == null)
            {
                existencia = new ExistenciaProducto
                {
                    NoParte = movimientoToCreate.NoParte,
                    PiezasCertificadas = movimientoToCreate.PiezasCertificadas,
                    PiezasRechazadas = (int)movimientoToCreate.PiezasRechazadas,
                    FechaCreacion = DateTime.Now,
                    CreadoPorId = userId
                };
                _repo.Add(existencia);
            }
            else
            {
                existencia.PiezasCertificadas += movimientoToCreate.PiezasCertificadas;
                existencia.PiezasRechazadas += (int)movimientoToCreate.PiezasRechazadas;
                existencia.UltimaModificacion = DateTime.Now;
                existencia.ModificadoPorId = userId;
            }

            if (movimientoToCreate.LocalidadId.HasValue && movimientoToCreate.PiezasCertificadas > 0)
            {
                var localidadNumeroParte = await _repo.GetLocalidadNumeroParte(movimientoToCreate.LocalidadId.Value, movimientoToCreate.NoParte);
                if (localidadNumeroParte == null)
                {
                    localidadNumeroParte = new LocalidadNumeroParte
                    {
                        NoParte = movimientoToCreate.NoParte,
                        LocalidadId = movimientoToCreate.LocalidadId.Value,
                        Existencia = movimientoToCreate.PiezasCertificadas,
                        FechaCreacion = DateTime.Now,
                        CreadoPorId = userId
                    };
                    _repo.Add(localidadNumeroParte);
                }
                else
                {
                    localidadNumeroParte.Existencia += movimientoToCreate.PiezasCertificadas;
                    localidadNumeroParte.UltimaModificacion = DateTime.Now;
                    localidadNumeroParte.ModificadoPorId = userId;
                }

            }



            if (await _repo.SaveAll())
            {
                var movimientoToReturn = _mapper.Map<MovimientoProductoToListDto>(movimientoProducto);
                return CreatedAtAction("GetMovimientoProducto", new { id = movimientoProducto.MovimientoProductoId }, movimientoToReturn);
            }


            throw new Exception("Movimiento de producto no guardado");
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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var existencia = await _repo.GetExistenciaProducto(movimientoFP.NoParte);
            if (movimiento.NoParte != movimientoFP.NoParte)
            {
                var otraExistencia = await _repo.GetExistenciaProducto(movimiento.NoParte);
                if (otraExistencia != null)
                {
                    otraExistencia.PiezasCertificadas -= movimiento.PiezasCertificadas;
                    otraExistencia.PiezasRechazadas -= movimiento.PiezasRechazadas;
                    otraExistencia.UltimaModificacion = DateTime.Now;
                    otraExistencia.ModificadoPorId = userId;
                }
                if (existencia != null)
                {
                    existencia.PiezasCertificadas += movimientoFP.PiezasCertificadas;
                    existencia.PiezasRechazadas += (int)movimientoFP.PiezasRechazadas;
                    existencia.UltimaModificacion = DateTime.Now;
                    existencia.ModificadoPorId = userId;
                }

                var localidadNumeroParteOriginal = await _repo.GetLocalidadNumeroParte(movimiento.LocalidadId.Value, movimiento.NoParte);

                localidadNumeroParteOriginal.Existencia -= movimiento.PiezasCertificadas;
                localidadNumeroParteOriginal.UltimaModificacion = DateTime.Now;
                localidadNumeroParteOriginal.ModificadoPorId = userId;

                var localidadNumeroParte = await _repo.GetLocalidadNumeroParte(movimientoFP.LocalidadId.Value, movimientoFP.NoParte);
                if (localidadNumeroParte == null)
                {
                    localidadNumeroParte = new LocalidadNumeroParte
                    {
                        NoParte = movimientoFP.NoParte,
                        LocalidadId = movimientoFP.LocalidadId.Value,
                        Existencia = movimientoFP.PiezasCertificadas,
                        FechaCreacion = DateTime.Now,
                        CreadoPorId = userId
                    };
                    _repo.Add(localidadNumeroParte);
                }
                else
                {
                    localidadNumeroParte.Existencia += movimientoFP.PiezasCertificadas;
                    localidadNumeroParte.UltimaModificacion = DateTime.Now;
                    localidadNumeroParte.ModificadoPorId = userId;
                }


            }
            else
            {
                if (existencia != null)
                {
                    existencia.PiezasCertificadas += (movimientoFP.PiezasCertificadas - movimiento.PiezasCertificadas);
                    existencia.PiezasRechazadas += ((int)movimientoFP.PiezasRechazadas - movimiento.PiezasRechazadas);
                    existencia.UltimaModificacion = DateTime.Now;
                    existencia.ModificadoPorId = userId;
                }
                else
                {
                    existencia = new ExistenciaProducto { NoParte = movimientoFP.NoParte, PiezasCertificadas = movimientoFP.PiezasCertificadas, PiezasRechazadas = (int)movimientoFP.PiezasRechazadas, FechaCreacion = DateTime.Now, CreadoPorId = userId };
                    _repo.Add(existencia);
                }

                if (movimiento.LocalidadId != movimientoFP.LocalidadId)
                {
                    var localidadNumeroParteOriginal = await _repo.GetLocalidadNumeroParte(movimiento.LocalidadId.Value, movimiento.NoParte);
                    if (localidadNumeroParteOriginal != null)
                    {
                        localidadNumeroParteOriginal.Existencia -= movimiento.PiezasCertificadas;
                        localidadNumeroParteOriginal.UltimaModificacion = DateTime.Now;
                        localidadNumeroParteOriginal.ModificadoPorId = userId;
                    }


                    var localidadNumeroParte = await _repo.GetLocalidadNumeroParte(movimientoFP.LocalidadId.Value, movimientoFP.NoParte);
                    if (localidadNumeroParte == null)
                    {
                        localidadNumeroParte = new LocalidadNumeroParte
                        {
                            NoParte = movimientoFP.NoParte,
                            LocalidadId = movimientoFP.LocalidadId.Value,
                            Existencia = movimientoFP.PiezasCertificadas,
                            FechaCreacion = DateTime.Now,
                            CreadoPorId = userId
                        };
                        _repo.Add(localidadNumeroParte);
                    }
                    else
                    {
                        localidadNumeroParte.Existencia += movimientoFP.PiezasCertificadas;
                        localidadNumeroParte.UltimaModificacion = DateTime.Now;
                        localidadNumeroParte.ModificadoPorId = userId;
                    }
                }
                else
                {
                    var localidadNumeroParte = await _repo.GetLocalidadNumeroParte(movimientoFP.LocalidadId.Value, movimientoFP.NoParte);
                    if (localidadNumeroParte == null)
                    {
                        localidadNumeroParte = new LocalidadNumeroParte
                        {
                            NoParte = movimientoFP.NoParte,
                            LocalidadId = movimientoFP.LocalidadId.Value,
                            Existencia = movimientoFP.PiezasCertificadas,
                            FechaCreacion = DateTime.Now,
                            CreadoPorId = userId
                        };
                        _repo.Add(localidadNumeroParte);
                    }
                    else
                    {
                        localidadNumeroParte.Existencia += (movimientoFP.PiezasCertificadas - movimiento.PiezasCertificadas);
                        localidadNumeroParte.UltimaModificacion = DateTime.Now;
                        localidadNumeroParte.ModificadoPorId = userId;
                    }
                }
            }




            movimientoFP.TipoMovimiento = "Entrada Almacen";

            _mapper.Map(movimientoFP, movimiento);

            movimiento.ModificadoPorId = userId;
            movimiento.UltimaModificacion = DateTime.Now;

            await _repo.SaveAll();
            return NoContent();


        }
    }
}
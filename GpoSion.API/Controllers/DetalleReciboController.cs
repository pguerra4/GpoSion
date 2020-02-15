using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{
    [Authorize(Policy = "AlmacenRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleReciboController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;

        public DetalleReciboController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleRecibo(int Id)
        {
            var detalleRecibo = await _repo.GetDetalleRecibo(Id);
            if (detalleRecibo == null)
                return BadRequest();

            var detalleReciboToReturn = _mapper.Map<DetalleReciboForDetailDto>(detalleRecibo);
            return Ok(detalleReciboToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostDetalleRecibo(ICollection<DetalleReciboForPostDto> detallesRecibo)
        {

            var recibo = await _repo.GetRecibo(detallesRecibo.FirstOrDefault().ReciboId);

            if (recibo == null)
                return BadRequest();


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // var cliente = await _repo.GetCliente(recibo.ClienteId.Value);
            var almacenes = await _repo.GetAreas();
            var almacen = almacenes.FirstOrDefault(a => a.NombreArea.ToLower() == "almacen");


            // var detalles = _mapper.Map<ICollection<DetalleRecibo>>(detallesRecibo);




            foreach (DetalleReciboForPostDto detalle in detallesRecibo)
            {
                // var material = await _repo.GetMaterialByClienteNombre(recibo.ClienteId.Value, detalle.Material);
                var material = await _repo.GetMaterial(detalle.MaterialId);
                var unidadMedida = await _repo.GetUnidadMedida(detalle.UnidadMedidaId);



                // if (material == null)
                // {

                //     material = new Material { ClaveMaterial = detalle.Material, Cliente = cliente, UnidadMedida = unidadMedida, FechaCreacion = DateTime.Now };
                //     _repo.Add(material);
                //     await _repo.SaveAll();
                // }

                var viajero = await _repo.GetViajero(detalle.Viajero);
                if (viajero == null)
                {

                    viajero = new Viajero { ViajeroId = detalle.Viajero, Fecha = DateTime.Now, Existencia = detalle.Total, MaterialId = material.MaterialId, Material = material, LocalidadId = detalle.LocalidadId, CreadoPorId = userId, FechaCreacion = DateTime.Now };
                    _repo.Add(viajero);
                    await _repo.SaveAll();

                }
                else
                {
                    viajero.Existencia += detalle.Total;
                    viajero.UltimaModificacion = DateTime.Now;
                    viajero.ModificadoPorId = userId;
                }

                if (detalle.LocalidadId.HasValue)
                {

                    var localidadMaterial = await _repo.GetLocalidadMaterial(detalle.LocalidadId.Value, detalle.MaterialId);
                    if (localidadMaterial == null)
                    {
                        localidadMaterial = new LocalidadMaterial { MaterialId = detalle.MaterialId, LocalidadId = detalle.LocalidadId.Value, Existencia = detalle.Total, CreadoPorId = userId, FechaCreacion = DateTime.Now };
                        _repo.Add(localidadMaterial);
                    }
                    else
                    {
                        localidadMaterial.Existencia += detalle.Total;
                        localidadMaterial.ModificadoPorId = userId;
                        localidadMaterial.UltimaModificacion = DateTime.Now;
                    }
                }



                var movMaterial = new MovimientoMaterial { Fecha = DateTime.Now, Material = material, Cantidad = detalle.Total, Origen = null, Destino = almacen, Recibo = recibo, Viajero = viajero, LocalidadId = detalle.LocalidadId, CreadoPorId = userId, FechaCreacion = DateTime.Now };
                _repo.Add(movMaterial);


                var existenciaMaterial = await _repo.GetExistenciaPorAreaMaterial(almacen.AreaId, material.MaterialId);
                if (existenciaMaterial == null)
                {
                    existenciaMaterial = new ExistenciaMaterial
                    {
                        Material = material,
                        Area = almacen,
                        Existencia = detalle.Total,
                        FechaCreacion = DateTime.Now,
                        CreadoPorId = userId
                    };
                    _repo.Add(existenciaMaterial);
                }
                else
                {
                    existenciaMaterial.Existencia += detalle.Total;
                    existenciaMaterial.ModificadoPorId = userId;
                    existenciaMaterial.UltimaModificacion = DateTime.Now;
                }


                var detalleRecibo = new DetalleRecibo
                {
                    TotalCajas = !detalle.TotalCajas.HasValue ? 0 : detalle.TotalCajas.Value,
                    CantidadPorCaja = !detalle.CantidadPorCaja.HasValue ? 0 : detalle.CantidadPorCaja.Value,
                    Total = detalle.Total,
                    Referencia2 = detalle.Referencia2,
                    Viajero = viajero,
                    ReferenciaCliente = detalle.ReferenciaCliente,
                    Recibo = recibo,
                    MaterialId = material.MaterialId,
                    Material = material,
                    UnidadMedida = unidadMedida,
                    LocalidadId = detalle.LocalidadId,
                    NoLote = detalle.NoLote,
                    CreadoPorId = userId,
                    FechaCreacion = DateTime.Now
                };

                _repo.Add(detalleRecibo);
            }
            recibo.IsComplete = true;

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Recibo no guardado");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleRecibo(int Id, DetalleReciboForPutDto detalleReciboForEdit)
        {

            var detalleRecibo = await _repo.GetDetalleRecibo(Id);

            if (detalleRecibo == null)
                return BadRequest();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var almacenes = await _repo.GetAreas();
            var almacen = almacenes.FirstOrDefault(a => a.NombreArea.ToLower() == "almacen");



            var unidadMedida = await _repo.GetUnidadMedida(detalleReciboForEdit.UnidadMedidaId);
            var viajero = await _repo.GetViajero(detalleReciboForEdit.Viajero);
            viajero.LocalidadId = detalleReciboForEdit.LocalidadId;



            var diferencia = detalleReciboForEdit.Total - detalleRecibo.Total;
            viajero.Existencia += diferencia;

            if (detalleReciboForEdit.LocalidadId.HasValue)
            {
                if (detalleRecibo.LocalidadId != detalleReciboForEdit.LocalidadId)
                {
                    var localidadMaterialOriginal = await _repo.GetLocalidadMaterial(detalleRecibo.LocalidadId.Value, detalleRecibo.MaterialId);
                    localidadMaterialOriginal.Existencia -= detalleRecibo.Total;
                    localidadMaterialOriginal.ModificadoPorId = userId;
                    localidadMaterialOriginal.UltimaModificacion = DateTime.Now;


                    var localidadMaterial = await _repo.GetLocalidadMaterial(detalleReciboForEdit.LocalidadId.Value, detalleReciboForEdit.MaterialId);
                    if (localidadMaterial == null)
                    {
                        localidadMaterial = new LocalidadMaterial { MaterialId = detalleReciboForEdit.MaterialId, LocalidadId = detalleReciboForEdit.LocalidadId.Value, Existencia = detalleReciboForEdit.Total, CreadoPorId = userId, FechaCreacion = DateTime.Now };
                        _repo.Add(localidadMaterial);
                    }
                    else
                    {
                        localidadMaterial.Existencia += detalleReciboForEdit.Total;
                        localidadMaterial.ModificadoPorId = userId;
                        localidadMaterial.UltimaModificacion = DateTime.Now;
                    }

                }
                else
                {
                    // var localidad = await _repo.GetLocalidad(detalleReciboForEdit.LocalidadId.Value);

                    var localidadMaterial = await _repo.GetLocalidadMaterial(detalleReciboForEdit.LocalidadId.Value, detalleReciboForEdit.MaterialId);

                    localidadMaterial.Existencia += diferencia;
                    localidadMaterial.ModificadoPorId = userId;
                    localidadMaterial.UltimaModificacion = DateTime.Now;

                }
            }

            var movsMaterial = await _repo.GetMovimientoMaterialesPorViajero(viajero.ViajeroId);
            var movMaterial = movsMaterial.Where(mm => mm.Destino == almacen && mm.Origen == null && mm.Recibo == detalleRecibo.Recibo).FirstOrDefault();
            movMaterial.Cantidad = detalleReciboForEdit.Total;
            movMaterial.ModificadoPorId = userId;
            movMaterial.UltimaModificacion = DateTime.Now;
            movMaterial.MotivoMovimiento = detalleReciboForEdit.MotivoMovimiento;
            movMaterial.LocalidadId = detalleReciboForEdit.LocalidadId;

            var existenciaMaterial = await _repo.GetExistenciaPorAreaMaterial(almacen.AreaId, detalleRecibo.Material.MaterialId);

            existenciaMaterial.Existencia += diferencia;
            existenciaMaterial.UltimaModificacion = DateTime.Now;
            existenciaMaterial.ModificadoPorId = userId;


            detalleRecibo.TotalCajas = !detalleReciboForEdit.TotalCajas.HasValue ? 0 : detalleReciboForEdit.TotalCajas.Value;
            detalleRecibo.CantidadPorCaja = !detalleReciboForEdit.CantidadPorCaja.HasValue ? 0 : detalleReciboForEdit.CantidadPorCaja.Value;
            detalleRecibo.Total = detalleReciboForEdit.Total;
            detalleRecibo.Referencia2 = detalleReciboForEdit.Referencia2;
            detalleRecibo.ReferenciaCliente = detalleReciboForEdit.ReferenciaCliente;
            detalleRecibo.UnidadMedida = unidadMedida;
            detalleRecibo.LocalidadId = detalleReciboForEdit.LocalidadId;
            detalleRecibo.NoLote = detalleReciboForEdit.NoLote;
            detalleRecibo.ModificadoPorId = userId;
            detalleRecibo.UltimaModificacion = DateTime.Now;





            await _repo.SaveAll();
            return NoContent();

            throw new Exception("Recibo no guardado");
        }

    }
}
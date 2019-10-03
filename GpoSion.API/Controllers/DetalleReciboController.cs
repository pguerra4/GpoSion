using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{
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

        [HttpPost()]
        public async Task<IActionResult> PostDetalleRecibo(ICollection<DetalleReciboForPostDto> detallesRecibo)
        {

            var recibo = await _repo.GetRecibo(detallesRecibo.FirstOrDefault().ReciboId);

            if (recibo == null)
                return BadRequest();

            var cliente = await _repo.GetCliente(recibo.ClienteId.Value);
            var almacenes = await _repo.GetAreas();
            var almacen = almacenes.FirstOrDefault(a => a.NombreArea.ToLower() == "almacen");


            // var detalles = _mapper.Map<ICollection<DetalleRecibo>>(detallesRecibo);




            foreach (DetalleReciboForPostDto detalle in detallesRecibo)
            {
                var material = await _repo.GetMaterialByClienteNombre(recibo.ClienteId.Value, detalle.Material);
                var unidadMedida = await _repo.GetUnidadMedida(detalle.UnidadMedidaId);
                if (material == null)
                {

                    material = new Material { ClaveMaterial = detalle.Material, Cliente = cliente, UnidadMedida = unidadMedida, FechaCreacion = DateTime.Now };
                    _repo.Add(material);
                    await _repo.SaveAll();
                }

                var movMaterial = new MovimientoMaterial { Fecha = DateTime.Now, Material = material, Cantidad = detalle.Total, Origen = almacen, Destino = almacen, Recibo = recibo, Viajero = detalle.Viajero };
                _repo.Add(movMaterial);


                var existenciaMaterial = await _repo.GetExistenciaPorAreaMaterial(almacen.AreaId, material.MaterialId);
                if (existenciaMaterial == null)
                {
                    existenciaMaterial = new ExistenciaMaterial
                    {
                        Material = material,
                        Area = almacen,
                        Existencia = detalle.Total,
                        UltimaModificacion = DateTime.Now
                    };
                    _repo.Add(existenciaMaterial);
                }
                else
                {
                    existenciaMaterial.Existencia += detalle.Total;
                }

                var detalleRecibo = new DetalleRecibo
                {
                    TotalCajas = !detalle.TotalCajas.HasValue ? 0 : detalle.TotalCajas.Value,
                    CantidadPorCaja = !detalle.CantidadPorCaja.HasValue ? 0 : detalle.CantidadPorCaja.Value,
                    Total = detalle.Total,
                    Referencia2 = detalle.Referencia2,
                    Viajero = detalle.Viajero,
                    ReferenciaCliente = detalle.ReferenciaCliente,
                    Recibo = recibo,
                    Material = material,
                    UnidadMedida = unidadMedida
                };

                _repo.Add(detalleRecibo);
            }


            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Recibo no guardado");
        }
    }
}
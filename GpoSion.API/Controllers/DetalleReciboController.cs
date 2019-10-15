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

                var viajero = await _repo.GetViajero(detalle.Viajero);
                if (viajero == null)
                {
                    viajero = new Viajero { ViajeroId = detalle.Viajero, Fecha = DateTime.Now, Existencia = detalle.Total, MaterialId = material.MaterialId, Material = material, Localidad = detalle.Localidad };
                }
                else
                {
                    viajero.Existencia += detalle.Total;
                }

                var movMaterial = new MovimientoMaterial { Fecha = DateTime.Now, Material = material, Cantidad = detalle.Total, Origen = null, Destino = almacen, Recibo = recibo, Viajero = viajero };
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
                    Viajero = viajero,
                    ReferenciaCliente = detalle.ReferenciaCliente,
                    Recibo = recibo,
                    Material = material,
                    UnidadMedida = unidadMedida
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


            var almacenes = await _repo.GetAreas();
            var almacen = almacenes.FirstOrDefault(a => a.NombreArea.ToLower() == "almacen");



            var unidadMedida = await _repo.GetUnidadMedida(detalleReciboForEdit.UnidadMedidaId);


            var viajero = await _repo.GetViajero(detalleReciboForEdit.Viajero);
            viajero.Localidad = detalleReciboForEdit.Localidad;

            var diferencia = detalleReciboForEdit.Total - detalleRecibo.Total;


            viajero.Existencia += diferencia;


            var movsMaterial = await _repo.GetMovimientoMaterialesPorViajero(viajero.ViajeroId);
            var movMaterial = movsMaterial.Where(mm => mm.Destino == almacen && mm.Origen == null && mm.Recibo == detalleRecibo.Recibo).FirstOrDefault();
            movMaterial.Cantidad = detalleReciboForEdit.Total;

            var existenciaMaterial = await _repo.GetExistenciaPorAreaMaterial(almacen.AreaId, detalleRecibo.Material.MaterialId);

            existenciaMaterial.Existencia += diferencia;



            detalleRecibo.TotalCajas = !detalleReciboForEdit.TotalCajas.HasValue ? 0 : detalleReciboForEdit.TotalCajas.Value;
            detalleRecibo.CantidadPorCaja = !detalleReciboForEdit.CantidadPorCaja.HasValue ? 0 : detalleReciboForEdit.CantidadPorCaja.Value;
            detalleRecibo.Total = detalleReciboForEdit.Total;
            detalleRecibo.Referencia2 = detalleReciboForEdit.Referencia2;
            detalleRecibo.ReferenciaCliente = detalleReciboForEdit.ReferenciaCliente;
            detalleRecibo.UnidadMedida = unidadMedida;





            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Recibo no guardado");
        }

    }
}
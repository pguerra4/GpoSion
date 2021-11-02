using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class OrdenCompraProveedorToListDto
    {

        public string NoOrden { get; set; }
        public DateTime Fecha { get; set; }

        public DateTime? FechaEntrega { get; set; }


        public int CompradorId { get; set; }

        [JsonProperty("comprador")]
        public string CompradorNombre { get; set; }

        public int ProveedorId { get; set; }

        [JsonProperty("proveedor")]
        public string ProveedorNombre { get; set; }


        public string PersonaSolicita { get; set; }

        public string Departamento { get; set; }

        public string AreaProyecto { get; set; }

        public string RazonCompra { get; set; }

        public string Compra { get; set; }



        public ICollection<OrdenCompraProveedorDetalleToListDto> Materiales { get; set; }
    }
}
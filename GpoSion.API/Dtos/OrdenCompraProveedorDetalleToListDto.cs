using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class OrdenCompraProveedorDetalleToListDto
    {
        public int Id { get; set; }


        public int MaterialId { get; set; }

        [JsonProperty(PropertyName = "material")]
        public string MaterialClaveMaterial { get; set; }

        [JsonProperty(PropertyName = "noOrden")]
        public string OrdenCompraProveedorNoOrden { get; set; }

        public Decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }


        public Decimal PrecioUnitario { get; set; }


        public Decimal PrecioTotal { get; set; }

        public string Observaciones { get; set; }

        public DateTime UltimaModificacion { get; set; }


    }


}
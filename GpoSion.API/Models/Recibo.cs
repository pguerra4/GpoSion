using System;
using System.Collections.Generic;

namespace GpoSion.API.Models
{
    public class Recibo
    {
        public int ReciboId { get; set; }
        public int NoRecibo { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? HoraEntrada { get; set; }



        public string Transportista { get; set; }
        public string FacturaAduanal { get; set; }
        public string PedimentoImportacion { get; set; }

        public string NoLote { get; set; }
        public bool IsComplete { get; set; }

        public int? ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public string Recibio { get; set; }

        public string Descripcion { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }


        public ICollection<DetalleRecibo> Detalle { get; set; }


    }
}
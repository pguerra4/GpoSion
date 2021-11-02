using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("ProveedorId")]
        public virtual Proveedor Proveedor { get; set; }

        public string Recibio { get; set; }

        public string Descripcion { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }

        [ForeignKey("CreadoPorId")]
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }

        [ForeignKey("ModificadoPorId")]
        public virtual User ModificadoPor { get; set; }


        public virtual ICollection<DetalleRecibo> Detalle { get; set; }


    }
}
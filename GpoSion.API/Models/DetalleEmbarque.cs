using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class DetalleEmbarque
    {
        public int DetalleEmbarqueId { get; set; }

        public int EmbarqueId { get; set; }

        [ForeignKey("EmbarqueId")]
        public virtual Embarque Embarque { get; set; }

        public string NoParte { get; set; }

        [ForeignKey("NoParte")]
        public virtual NumeroParte NumeroParte { get; set; }

        public long? NoOrden { get; set; }

        [ForeignKey("NoOrden")]
        public virtual OrdenCompra OrdenCompra { get; set; }

        public int Cajas { get; set; }
        public int PiezasXCaja { get; set; }

        public int Entregadas { get; set; }

        public int? LocalidadId { get; set; }

        [ForeignKey("LocalidadId")]
        public virtual Localidad Localidad { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }

        [ForeignKey("CreadoPorId")]
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }

        [ForeignKey("ModificadoPorId")]
        public virtual User ModificadoPor { get; set; }

        public virtual ICollection<MovimientoProducto> Movimientos { get; set; }


    }
}
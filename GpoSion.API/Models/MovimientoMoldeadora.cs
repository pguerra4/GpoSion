using System;
using System.Collections.Generic;

namespace GpoSion.API.Models
{
    public class MovimientoMoldeadora
    {
        public int MovimientoMoldeadoraId { get; set; }

        public int MoldeadoraId { get; set; }
        public virtual Moldeadora Moldeadora { get; set; }

        public string Movimiento { get; set; }

        public string Observaciones { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


        public string Estatus { get; set; }

        public int? MoldeId { get; set; }
        public virtual Molde Molde { get; set; }

        public int? MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public virtual ICollection<MovimientoMoldeadoraNumeroParte> MovimientoMoldeadoraNumerosParte { get; set; }

        public int? MotivoTiempoMuertoId { get; set; }
        public virtual MotivoTiempoMuerto MotivoTiempoMuerto { get; set; }


    }
}
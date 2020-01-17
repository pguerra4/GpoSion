using System;
using System.Collections.Generic;

namespace GpoSion.API.Models
{
    public class RequerimientoMaterial
    {
        public int RequerimientoMaterialId { get; set; }
        public DateTime FechaSolicitud { get; set; }

        public int? TurnoId { get; set; }
        public Turno Turno { get; set; }

        public string JefaLinea { get; set; }

        public DateTime? Fechaentrega { get; set; }

        public string Almacenista { get; set; }

        public string Recibio { get; set; }

        public string Estatus { get; set; }

        public bool IsRead { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }


        public ICollection<RequerimientoMaterialMaterial> Materiales { get; set; }

        public RequerimientoMaterial()
        {
            FechaSolicitud = DateTime.Now;
            IsRead = false;
            Estatus = "Nuevo";
        }


    }
}
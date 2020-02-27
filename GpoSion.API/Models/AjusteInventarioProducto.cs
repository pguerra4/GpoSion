using System;

namespace GpoSion.API.Models
{
    public class AjusteInventarioProducto
    {
        public int AjusteInventarioProductoId { get; set; }

        public DateTime Fecha { get; set; }

        public string Motivo { get; set; }

        public string CreadoPorId { get; set; }

        public virtual User CreadorPor { get; set; }

        public int ExistenciaOriginal { get; set; }
        public int ExistenciaFinal { get; set; }

        public int? ExistenciaProductoId { get; set; }
        public virtual ExistenciaProducto ExistenciaProducto { get; set; }

        public int? LocalidadId { get; set; }

        public string NoParte { get; set; }
        public virtual LocalidadNumeroParte LocalidadNumeroParte { get; set; }

    }
}
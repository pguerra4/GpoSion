using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Column("Usuario")]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }

        public bool Activo { get; set; }


        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }

    }
}
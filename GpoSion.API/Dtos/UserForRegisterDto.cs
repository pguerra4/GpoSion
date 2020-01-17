using System.ComponentModel.DataAnnotations;

namespace GpoSion.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "La contraseña debe ser de al menos {0} caracteres")]
        public string Password { get; set; }

        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }

        public string eMail { get; set; }


    }
}
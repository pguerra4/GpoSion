using System.ComponentModel.DataAnnotations;

namespace GpoSion.API.Dtos
{
    public class UserForPasswordChangeDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "La contraseña debe ser de al menos {2} caracteres")]
        public string NewPassword { get; set; }

        public string OldPassword { get; set; }


    }
}
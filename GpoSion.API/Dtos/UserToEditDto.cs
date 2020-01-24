using System.ComponentModel.DataAnnotations;

namespace GpoSion.API.Dtos
{
    public class UserToEditDto
    {
        [Required]
        public string Id { get; set; }

        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }

        public string eMail { get; set; }

        public string[] Roles { get; set; }



    }
}
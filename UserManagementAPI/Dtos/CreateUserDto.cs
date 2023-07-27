using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Dtos
{
    public class CreateUserDto
    {
        [Required (ErrorMessage = "Se debe especificar el nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Se debe especificar el nombre")]
        public string Lastname { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El email no es correcto")]
        public string Email { get; set; }

        public bool Enable { get; set; }
    }
}

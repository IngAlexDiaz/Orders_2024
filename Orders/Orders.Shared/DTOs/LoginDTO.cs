using System.ComponentModel.DataAnnotations;

namespace Orders.Shared.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser un correo electrónico válido.")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MinLength(6, ErrorMessage = "El campo {0} debe tener mínimo {1} caractéres.")]
        public string Password { get; set; } = null!;
    }
}
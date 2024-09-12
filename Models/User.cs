using System.ComponentModel.DataAnnotations;

namespace riwi.Models
{
    public class User
    {
        /* public string? Name { get; set; } */
/*         [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email no válido")] */
        public string? Email { get; set; }

        /* [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")] */
        public string? Password { get; set; }
    }
}
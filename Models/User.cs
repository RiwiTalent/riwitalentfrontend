using System.ComponentModel.DataAnnotations;

namespace riwitalentfrontend.Models
{
    public class User
    {
        // Correo electrónico del usuario
        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido.")]
        public string Email { get; set; } = string.Empty;

        // Contraseña del usuario
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;

namespace riwitalentfrontend.Models
{
    public class Group
    {
        // Identificador único del grupo
        [Required]
        public string Id { get; set; } = string.Empty;

        // Nombre del grupo
        [Required]
        public string Name { get; set; } = string.Empty;

        // Photo del grupo
        public string Photo { get; set; } = null;

        // Descripción del grupo
        public string Description { get; set; } = string.Empty;

        // Estado del grupo (activo, inactivo, etc.)
        public string Status { get; set; } = "Active";

        // Fecha de creación del grupo
        public DateTime CreatedAt { get; set; } 
        
        // Email del creador del grupo
        [Required]
        public string? CreatedBy { get; set; }

        // Email de la empresa asociada al grupo
        [Required]
        public string? AssociateEmail { get; set; }


        public DateTime ExpirationAt { get; set; }

        // Lista de coders que pertenecen al grupo
        public List<Coder>? Coders { get; set; } = new List<Coder>();


        // Lista de claves externas asociadas al grupo
        public List<ExternalKey> ExternalKeys { get; set; } = new List<ExternalKey>();
    }
}
using System.ComponentModel.DataAnnotations;

namespace riwitalentfrontend.Models.DTOs
{
    public class GroupAddDto
    {
        // Nombre del grupo
        public string Name { get; set; } = String.Empty;

        // Descripción del grupo
        public string? Description { get; set; } = String.Empty;

        // Correo electrónico del asociado al grupo
        public string AssociateEmail { get; set; } = String.Empty;
        
        // Correo del creador del grupo
        public string CreatedBy { get; set; } = String.Empty;
    }
}
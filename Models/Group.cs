namespace riwitalentfrontend.Models
{
    public class Group
    {
        // Identificador único del grupo
        public string Id { get; set; } = string.Empty;

        // Nombre del grupo
        public string Name { get; set; } = string.Empty;

        // Photo del grupo
        public string Photo { get; set; } = null;

        // Descripción del grupo
        public string Description { get; set; } = string.Empty;

        // Estado del grupo (activo, inactivo, etc.)
        public string Status { get; set; } = string.Empty;
        
        // Email del creador del grupo
        public string? CreatedBy { get; set; }

        // Email de la empresa asociada al grupo
        public string? AssociateEmail { get; set; }

        // Fecha de creación del grupo
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime Expiration_At { get; set; }

        // Lista de coders que pertenecen al grupo
        public List<Coder>? Coders { get; set; } = new List<Coder>();


        // Lista de claves externas asociadas al grupo
        public List<ExternalKey> ExternalKeys { get; set; } = new List<ExternalKey>();
    }
}
namespace riwitalentfrontend.Models
{
    public class Group
    {
        // Identificador único del grupo
        public string Id { get; set; } = string.Empty;

        // Nombre del grupo
        public string Name { get; set; } = string.Empty;

        // Descripción del grupo
        public string Description { get; set; } = string.Empty;

        // Estado del grupo (activo, inactivo, etc.)
        public string Status { get; set; } = string.Empty;

        // Fecha de creación del grupo
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Lista de claves externas asociadas al grupo
        public List<ExternalKey> ExternalKeys { get; set; } = new List<ExternalKey>();

        // Lista de coders que pertenecen al grupo
        public List<Coder>? Coders { get; set; } = new List<Coder>();
    }
}
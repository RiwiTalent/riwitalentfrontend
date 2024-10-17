namespace riwitalentfrontend.Models
{
    public class CodersInGroup
    {
        // Identificador único del grupo de coders
        public string Id { get; set; } = string.Empty;

        // Nombre del grupo de coders
        public string Name { get; set; } = string.Empty;

        // Descripción del grupo
        public string Description { get; set; } = string.Empty;

        // Lista de coders que pertenecen a este grupo
        public List<Coder>? Coders { get; set; }
    }
}
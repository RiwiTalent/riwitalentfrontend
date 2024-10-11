namespace riwitalentfrontend.Models
{
    public class ExternalKey
    {
        // URL asociada a la clave externa
        public string Url { get; set; } = string.Empty;

        // Clave de acceso externa
        public string Key { get; set; } = string.Empty;

        // Estado de la clave externa
        public string Status { get; set; } = string.Empty;

        // Fecha de creación de la clave externa
        public DateTime DateCreation { get; set; } = DateTime.Now;

        // Fecha de expiración de la clave externa (15 días a partir de la creación)
        public DateTime DateExpiration { get; set; } = DateTime.Now + TimeSpan.FromDays(15);
    }
}
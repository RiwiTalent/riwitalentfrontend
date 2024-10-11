namespace riwitalentfrontend.Models
{
    public class LanguageSkill
    {
        // Idioma que el coder tiene como habilidad
        public string Language { get; set; } = string.Empty;

        // Nivel de habilidad en el idioma (ej. Básico, Intermedio, Avanzado)
        public string LanguageLevel { get; set; } = string.Empty;
    }
}
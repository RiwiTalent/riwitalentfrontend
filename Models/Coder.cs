namespace riwitalentfrontend.Models
{
    public class Coder
    {
        // Identificador único del coder
        public string Id { get; set; } = string.Empty;

        // Nombres del coder
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;

        // Apellidos del coder
        public string FirstLastName { get; set; } = string.Empty;
        public string SecondLastName { get; set; } = string.Empty;

        // Información de contacto
        public string Email { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;

        // Datos adicionales
        public int Age { get; set; } = 0;
        public string Status { get; set; } = "Active";

        // Fecha de creación del perfil
        public DateTime DateCreation { get; set; }

        // Tecnologías en las que el coder es competente
        public string Stack { get; set; } = string.Empty;
        
        // Puntaje de desempeño
        public float AssessmentScore { get; set; }

        // Estandar Riwi
        public StandarRiwi? StandarRiwi { get; set; }

        // Habilidades del coder
        public List<Skill>? Skills { get; set; }

        // Habilidades lingüísticas del coder
        public LanguageSkill? LanguageSkills { get; set; }
    }
}
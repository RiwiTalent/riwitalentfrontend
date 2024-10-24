using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace riwitalentfrontend.Models.DTOs
{
    public class CoderAddDto
    {
        public string FirstName { get; set; } = String.Empty;
        public string SecondName { get; set; } = String.Empty;
        public string FirstLastName { get; set; } = String.Empty;
        public string SecondLastName { get; set; } = String.Empty;
        public string Email { get; set; } = string.Empty;
        public string Stack { get; set; } = string.Empty;
        public int AssessmentScore { get; set; }
        public string Phone { get; set; } = string.Empty;
        public int Age { get; set; }    
        public string ProfessionalDescription { get; set; } = string.Empty;


        
    }
}
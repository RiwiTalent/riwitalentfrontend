using riwitalentfrontend.Models;
using riwitalentfrontend.Services.Interfaces;
using System.Collections.Generic;
using System.Linq; // Necesario para LINQ

namespace riwitalentfrontend.Services.Implementations
{
    public class SkillService : ISkillService
    {
        // Método para obtener habilidades únicas a partir de una lista de coders
        public List<string> GetUniqueSkills(List<Coder> coders)
        {
            // Usar un HashSet para almacenar habilidades únicas
            var skillsSet = new HashSet<string>();

            // Utilizando LINQ para obtener las habilidades únicas
            coders
                .Where(coder => coder.Skills != null)
                .SelectMany(coder => coder.Skills)
                .Where(skill => !string.IsNullOrEmpty(skill.Language_Programming)) 
                .ToList() // Convierte a lista
                .ForEach(skill => skillsSet.Add(skill.Language_Programming));
            
            return skillsSet.ToList();
        }
    }
}
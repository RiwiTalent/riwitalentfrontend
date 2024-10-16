using riwitalentfrontend.Models;
using riwitalentfrontend.Services.Interfaces;

namespace riwitalentfrontend.Services.Implementations;

public class SkillService : ISkillService
{
    public List<string> GetUniqueSkills(List<Coder> coders)
    {
        var skillsSet = new HashSet<string>();
        
        foreach (var coder in coders)
        {
            if (coder.Skills != null)
            {
                foreach (var skill in coder.Skills)
                {
                    if (!string.IsNullOrEmpty(skill.Language_Programming))
                    {
                        skillsSet.Add(skill.Language_Programming);
                    }
                }
            }
        }
        return skillsSet.ToList();
    }
}
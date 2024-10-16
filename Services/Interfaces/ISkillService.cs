using riwitalentfrontend.Models;

namespace riwitalentfrontend.Services.Interfaces;

public interface ISkillService
{
    public List<string> GetUniqueSkills(List<Coder> coders);
}
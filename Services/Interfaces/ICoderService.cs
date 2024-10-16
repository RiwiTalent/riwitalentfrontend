using riwitalentfrontend.Models;

namespace riwitalentfrontend.Services.Interfaces
{
    public interface ICoderService
    {
        Task<List<Coder>> GetCodersAsync();
        Task<bool> UpdateCoderAsync(Coder coder);
        Task<List<Coder>> FilterCodersBySkillsAsync(List<string> skills);
    }
}


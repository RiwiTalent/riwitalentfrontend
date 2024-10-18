using riwitalentfrontend.Models;

namespace riwitalentfrontend.Services.Interfaces
{
    public interface ICoderService
    {
        Task<List<Coder>> GetCodersAsync();
        Task<bool> UpdateCoderAsync(Coder coder);

        Task <Coder> GetCoderByIdAsync(string Id);

        Task<bool> DeleteCodersAsync(string Id);




        Task<List<Coder>> FilterCodersBySkillsAsync(List<string> skills);
    }
}


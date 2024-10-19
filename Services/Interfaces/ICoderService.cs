using riwitalentfrontend.Models;

namespace riwitalentfrontend.Services.Interfaces
{
    public interface ICoderService
    {
        Task<List<Coder>> GetCodersAsync();
        Task<bool> UpdateCoderAsync(Coder coder);

        Task <Coder> GetCoderByIdAsync(string Id);

        /*This update the coder status to 'Inactivo'*/
        Task<bool> DeleteCodersAsync(string Id);

        Task<bool> DeleteCoderOfGroup(string coderId, string groupId);

        Task<List<Coder>> FilterCodersBySkillsAsync(List<string> skills);
    }
}


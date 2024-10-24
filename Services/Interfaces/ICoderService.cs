using riwitalentfrontend.Models;
using riwitalentfrontend.Models.DTOs;

namespace riwitalentfrontend.Services.Interfaces
{
    public interface ICoderService
    {
        Task<List<Coder>> GetCodersAsync();
        Task<bool> UpdateCoderAsync(Coder coder);
        Task <Coder> GetCoderByIdAsync(string Id);
        Task<bool> AddCoderAsync(CoderAddDto coderAddDto);
        Task<bool> CodersGroupedAsync(DataDto data);
        Task<bool> CoderSelectedAsync(DataDto data);
        Task<bool> DeleteCodersAsync(string Id);
        Task<List<Coder>> FilterCodersBySkillsAsync(List<string> skills);
        Task<List<Coder>> GetCodersByLanguage(List<string> languageLevels);
        Task<bool> UploadCoderPhoto(string coderId, Stream stream, string fileName);
        Task<bool> UploadCvCoder(string coderId, Stream stream, string fileName);
        Task<string> DownloadCv(string coderId);

    }
}
namespace riwi.Services.Implementations;
using riwi.Models;

public interface ICoderService
{
    Task<List<Coder>> GetCodersAsync();
    Task<bool> UpdateCoderAsync(Coder coder);
}
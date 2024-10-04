namespace riwi.Services.Implementations;
using riwi.Models;
using riwi.Models.DTOs;

public interface IGroupService
{
        Task<List<Group>> GetGroupsAsync();
        Task<Group> GetGroupByIdAsync(string groupId);
        Task<bool> DeleteGroupAsync(string groupId);
        Task<bool> AddGroupAsync(GroupAddDto _groupAddDto);

}
using RTFrontend.Models;
using RTFrontend.Models.DTOs;

namespace RTFrontend.Services.Interfaces
{
        public interface IGroupService
        {
                Task<List<Group>> GetGroupsAsync();
                Task<Group> GetGroupByIdAsync(string groupId);
                Task<bool> DeleteGroupAsync(string groupId);
                Task<bool> AddGroupAsync(GroupAddDto _groupAddDto);

        }
}
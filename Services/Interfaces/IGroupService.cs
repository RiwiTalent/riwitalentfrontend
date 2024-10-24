using riwitalentfrontend.Models;
using riwitalentfrontend.Models.DTOs;



namespace riwitalentfrontend.Services.Interfaces
{
        public interface IGroupService
        {
                Task<List<Group?>> GetGroupsAsync();
                Task<Group> GetGroupByIdAsync(string groupId);
                Task<bool> Update(Group group);
                Task<bool> DeleteGroupAsync(string groupId);
                Task<bool> AddGroupAsync(GroupAddDto groupAddDto);
                Task<bool> RegenerateToken(string groupId);
                Task<bool> UploadGroupPhoto(string groupId, Stream stream, string fileName);
        } 
}
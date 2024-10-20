using System.Net.Http.Json;
using riwitalentfrontend.Models;
using riwitalentfrontend.Models.DTOs;
using riwitalentfrontend.Services.Interfaces;

namespace riwitalentfrontend.Services.Implementations
{
    public class GroupService  : IGroupService
    {
        private readonly HttpClient _httpClient;

        public GroupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        // Obtener lista de grupos desde la API
        public async Task<List<Group>> GetGroupsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Group>>("http://localhost:5113/groups");
        }
        
        // Obtener un grupo por Id desde la API
        public async Task<Group?> GetGroupByIdAsync(string groupId) // Group? permite que sea null
        {
            var response = await _httpClient.GetFromJsonAsync<Group>($"http://localhost:5113/groups/{groupId}/details");
            if (response != null)
            {
                Console.WriteLine("Details successfully fetched");
            }
            else
            {
                Console.WriteLine($"Error al obtener grupo por Id");
            }

            return response;

        }

        public async Task<bool> Update(Group group)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"http://localhost:5113/groups?Id={group.Id}&Name={group.Name}&Photo={group.Photo}&Description={group.Description}&Status={group.Status}&CreatedBy={group.CreatedBy}&AssociateEmail={group.AssociateEmail}&AcceptedTerms={group.AcceptedTerms}", group);
                response.EnsureSuccessStatusCode(); // Lanza una excepción si la solicitud no es exitosa
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el grupo: {ex.Message}");
                return false;
            }
        }

        
        // Lógica para obtener el grupo por Id desde la base de datos o API
        public async Task<bool> DeleteGroupAsync(string groupId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"http://localhost:5113/groups/{groupId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al desactivar grupo: {ex.Message}");
                return false;
            }
        }

        
        // Lógica para crear un grupo desde la base de datos o API
        public async Task<bool> AddGroupAsync(GroupAddDto groupAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5113/groups", groupAddDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegenerateToken(string groupId)
        {
            try
            {
                var url = $"http://localhost:5113/groups/regenerate-token";
                var response = await _httpClient.PatchAsync(url, JsonContent.Create(groupId));
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al regenerar el token: {ex.Message}");
                return false;
            }
        }
    }
}

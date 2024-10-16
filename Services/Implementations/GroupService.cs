using System.Net.Http.Json;
using riwitalentfrontend.Models;
using riwitalentfrontend.Models.DTOs;
using riwitalentfrontend.Services.Interfaces;

namespace riwitalentfrontend.Services.Implementations
{
    // Servicio para interactuar con la API de grupos
    public class GroupService  : IGroupService
    {
        
        // Inyección de HttpClient para realizar peticiones HTTP
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
            var response = await _httpClient.GetAsync($"http://localhost:5113/group-details/{groupId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Group>();
            }
            else
            {
                // Manejar el error en caso de que no se pueda obtener el grupo
                return null;
            }
        }
        
        // Eliminar un grupo por Id desde la API
        public async Task<bool> DeleteGroupAsync(string groupId)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5113/group/{groupId}");
            return response.IsSuccessStatusCode;
        }
        
        // Crear un grupo mediante un POST a la API
        public async Task<bool> AddGroupAsync(GroupAddDto groupAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5113/groups", groupAddDto);
            return response.IsSuccessStatusCode;
        }
    }
}

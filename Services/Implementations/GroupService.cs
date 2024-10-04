using System.Net.Http.Json;
using riwi.Models;
using riwi.Models.DTOs;
using riwi.Services.Implementations;

namespace riwi.Services
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
        
        // Lógica  para obtener una lista de coders desde la API
        public async Task<List<Group>> GetGroupsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Group>>("http://localhost:5113/groups");
        }
        
        // Lógica para obtener el grupo por Id desde la base de datos o API
        public async Task<Group> GetGroupByIdAsync(string groupId)
        {
            try
            {
                return await  _httpClient.GetFromJsonAsync<Group>($"http://localhost:5113/groupDetails/{groupId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener grupo por Id: {ex.Message}");
                return null;
            }
        }
        
        // Lógica para obtener el grupo por Id desde la base de datos o API
        public async Task<bool> DeleteGroupAsync(string groupId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"http://localhost:5113/group/{groupId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar grupo: {ex.Message}");
                return false;
            }
        }
        
        // Lógica para crear un grupo desde la base de datos o API
        public async Task<bool> AddGroupAsync(GroupAddDto _groupAddDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5113/groups", _groupAddDto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear grupo: {ex.Message}");
                return false;
            }
        }
    }
}

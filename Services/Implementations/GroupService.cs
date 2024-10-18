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
            
            var url = "http://localhost:5113/groups"; // Asegúrate de que esta URL sea correcta
            try
            {
                var jsonContent = JsonContent.Create(group);
                var response = await _httpClient.PutAsync(url, jsonContent);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                // Maneja la excepción (puedes registrar el error o mostrar un mensaje)
                Console.WriteLine($"Error al actualizar el grupo: {ex.Message}");
                return false; // Devuelve false en caso de error
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
                Console.WriteLine($"Error al eliminar grupo: {ex.Message}");
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
                var newKeyDto = new NewKeyDto { Id = groupId }; // Asegúrate de que NewKeyDto tenga una propiedad GroupId
                var response = await _httpClient.PatchAsync(url, JsonContent.Create(newKeyDto));
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

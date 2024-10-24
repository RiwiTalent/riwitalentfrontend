using System.Net.Http.Json;
using riwitalentfrontend.Models;
using riwitalentfrontend.Models.DTOs;
using riwitalentfrontend.Services.Interfaces;

namespace riwitalentfrontend.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly HttpClient _httpClient;

        public GroupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        // Obtener lista de grupos desde la API
        public async Task<List<Group>> GetGroupsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Group>>($"{GlobalConfig.ApiUrl}groups");
        }
        
        // Obtener un grupo por Id desde la API
        public async Task<Group?> GetGroupByIdAsync(string groupId) // Group? permite que sea null
        {
            var response = await _httpClient.GetFromJsonAsync<Group>($"{GlobalConfig.ApiUrl}groups/{groupId}/details");
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
                var response = await _httpClient.PutAsJsonAsync($"{GlobalConfig.ApiUrl}groups?Id={group.Id}&Name={group.Name}&Photo={group.Photo}&Description={group.Description}&Status={group.Status}&CreatedBy={group.CreatedBy}&AssociateEmail={group.AssociateEmail}&AcceptedTerms={group.AcceptedTerms}", group);
                response.EnsureSuccessStatusCode(); 
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
                var response = await _httpClient.DeleteAsync($"{GlobalConfig.ApiUrl}groups/{groupId}");
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
            var response = await _httpClient.PostAsJsonAsync($"{GlobalConfig.ApiUrl}groups", groupAddDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegenerateToken(string groupId)
        {
            try
            {
                var url = $"{GlobalConfig.ApiUrl}groups/regenerate-token";
                var response = await _httpClient.PatchAsync(url, JsonContent.Create(groupId));
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al regenerar el token: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UploadGroupPhoto(string groupId, Stream stream, string fileName)
        {
            if (stream == null || stream.Length == 0)
            {
                throw new ArgumentException("No file uploaded", nameof(stream));
            }

            using var content = new MultipartFormDataContent();
            var file = new StreamContent(stream);
            content.Add(file, "file", fileName);
            
            var response = await _httpClient.PostAsync($"{GlobalConfig.ApiUrl}group/photo/{groupId}", content);
            
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se subió de manera correcta la foto");
            }
            else
            {
                Console.WriteLine($"Error al cargar la foto {response.StatusCode}");
            }

            return response.IsSuccessStatusCode;
        }
    }
}

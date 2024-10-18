using System.Net.Http.Json;
using riwitalentfrontend.Services.Interfaces;
using riwitalentfrontend.Models;



namespace riwitalentfrontend.Services.Implementations
{
    // Servicio para interactuar con la API de coders
    public class CoderService : ICoderService
    {
        // Inyección de HttpClient para realizar peticiones HTTP
        private readonly HttpClient _httpClient;
        public CoderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        } 

        // Método para obtener una lista de coders desde la API
        public async Task<List<Coder>> GetCodersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Coder>>("https://backend-riwitalent-9pv2.onrender.com/coders");
        }

        public async Task<bool> UpdateCoderAsync(Coder coder)
        {
            var url = $"https://backend-riwitalent-9pv2.onrender.com/coders?Id={coder.Id}&FirstName={coder.FirstName}&SecondName={coder.SecondName}&FirstLastName={coder.FirstLastName}&SecondLastName={coder.SecondLastName}&Email={coder.Email}&Age={coder.Age}";
            
            var response = await _httpClient.PutAsync(url, null);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Coder>?> FilterCodersBySkillsAsync(List<string> skills)
        {
            var queryString = string.Join("&", skills.Select(skill => $"skills={Uri.EscapeDataString(skill)}"));
            var url = $"http://localhost:5113/coders?{queryString}";
            Console.WriteLine($"Request URL: {url}");
            return await _httpClient.GetFromJsonAsync<List<Coder>>(url);
        }

        public async Task<bool> DeleteCodersAsync(string Id)
        {
            
            try
                {
                    var response = await _httpClient.DeleteAsync($"http://localhost:5113/coders/{Id}");
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al desactivar coder: {ex.Message}");
                    return false;     
            }
        }

        public async Task<Coder> GetCoderByIdAsync(string Id)
        {
                // Realiza la solicitud GET para obtener los detalles del coder
                Console.WriteLine("entra a get coder BY id");
            var response = await _httpClient.GetFromJsonAsync<Coder>($"http://localhost:5113/coder/{Id}");
            
            if (response != null)
            {
                // Mensaje de éxito si el coder fue encontrado
                Console.WriteLine("Coder details successfully fetched");
            }
            else
            {
                // Mensaje de error si no se pudo obtener el coder
                Console.WriteLine("Error al obtener coder por Id");
            }

            return response; // Retorna el coder o null si no se encontró
        }
    }
}

using System.Net.Http.Json;
using riwi.Models;

namespace riwi.Services
{
    // Servicio para interactuar con la API de coders
    public class CoderService
    {
        private readonly HttpClient _httpClient;

        // Inyección de HttpClient para realizar peticiones HTTP
        public CoderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        } 

        // Método para obtener una lista de coders desde la API
        public async Task<List<Coder>> GetCodersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Coder>>("https://backend-riwitalent.onrender.com/riwitalent/coders");
        }
    }
}
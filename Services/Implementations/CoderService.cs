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
            var url = $"https://backend-riwitalent-9pv2.onrender.com/updatecoder?Id={coder.Id}&FirstName={coder.FirstName}&SecondName={coder.SecondName}&FirstLastName={coder.FirstLastName}&SecondLastName={coder.SecondLastName}&Email={coder.Email}&Age={coder.Age}";
            
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
    }
}

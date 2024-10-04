using System.Net.Http.Json;
using riwi.Models;
using riwi.Services.Implementations;

namespace riwi.Services
{
    // Servicio para interactuar con la API de coders
    public class CodersService : ICoderService
    {
        // Inyección de HttpClient para realizar peticiones HTTP
        private readonly HttpClient _httpClient;
        public CodersService(HttpClient httpClient)
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
            var url = $"https://backend-riwitalent-9pv2.onrender.com/riwitalent/updatecoder?Id={coder.Id}&FirstName={coder.FirstName}&SecondName={coder.SecondName}&FirstLastName={coder.FirstLastName}&SecondLastName={coder.SecondLastName}&Email={coder.Email}&Age={coder.Age}";
            
            var response = await _httpClient.PutAsync(url, null);
            return response.IsSuccessStatusCode;
        }

    }
}

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
            return await _httpClient.GetFromJsonAsync<List<Coder>>("https://backend-riwitalent-9pv2.onrender.com/riwitalent/coders");
        }

         public async Task<bool> UpdateCoderAsync(Coder coder)
        {
            var url = $"https://backend-riwitalent-9pv2.onrender.com/riwitalent/updatecoder?Id={coder.Id}&FirstName={coder.FirstName}&SecondName={coder.SecondName}&FirstLastName={coder.FirstLastName}&SecondLastName={coder.SecondLastName}&Email={coder.Email}&Age={coder.Age}";
            
            var response = await _httpClient.PutAsync(url, null); // Enviar como PUT sin cuerpo
            return response.IsSuccessStatusCode;
        }

    }
}

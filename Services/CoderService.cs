using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using riwi.Models;

namespace riwi.Services
{
    public class CoderService
    {
        private readonly HttpClient _httpClient;
        public CoderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        } 

        //we realize the petition
        public async Task<List<Coder>> GetCodersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Coder>>("http://localhost:5113/riwitalent/coders");
        }

         public async Task<bool> UpdateCoderAsync(Coder coder)
        {
            var url = $"http://localhost:5113/riwitalent/updatecoder?Id={coder.Id}&FirstName={coder.FirstName}&SecondName={coder.SecondName}&FirstLastName={coder.FirstLastName}&SecondLastName={coder.SecondLastName}&Email={coder.Email}&Age={coder.Age}";
            
            var response = await _httpClient.PutAsync(url, null); // Enviar como PUT sin cuerpo
            return response.IsSuccessStatusCode;
        }

    }
}
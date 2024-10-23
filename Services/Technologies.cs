using System.Net.Http.Json;
using riwitalentfrontend.Models;

namespace riwitalentfrontend.Services
{
    public static class TechnologiesService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<List<Technology>> GetTechnologiesAsync()
        {
            // Usar la URL global desde GlobalConfig
            var technologies = await _httpClient.GetFromJsonAsync<List<Technology>>($"{GlobalConfig.ApiUrl}technologies");
            return technologies ?? new List<Technology>();
        }
    }
}


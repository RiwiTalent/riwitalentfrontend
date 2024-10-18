using System.Net.Http.Json;
using riwitalentfrontend.Models;

namespace riwitalentfrontend.Services
{
    public static class TechnologiesService
    {
        private static HttpClient _httpClient = new HttpClient();

        public static async Task<List<Technology>> GetTechnologiesAsync()
        {
            var technologies = await _httpClient.GetFromJsonAsync<List<Technology>>("http://localhost:5113/technologies");
            return technologies ?? new List<Technology>();
        }
    }
}

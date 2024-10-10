using System.Net.Http.Json;
using riwitalentfrontend.Models;

namespace riwitalentfrontend.Services
{
    // Servicio para interactuar con la API de grupos
    public class GroupsServices
    {
        private readonly HttpClient _client;

        // Inyección de HttpClient para realizar peticiones HTTP
        public GroupsServices(HttpClient client)
        {
            _client = client;
        }

        // Método para obtener una lista de coders desde la API
        public async Task<List<Group>> GetGroupsAsync()
        {
            return await _client.GetFromJsonAsync<List<Group>>("https://backend-riwitalent-9pv2.onrender.com/groups");
        }
    }
}

using System.Net.Http.Json;
using riwi.Models;

namespace riwi.Services;

public class GroupsServices
{
    private readonly HttpClient _client;
    
    public GroupsServices(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Group>> GetGroupsAsync()
    {
        return await _client.GetFromJsonAsync<List<Group>>("http://localhost:5113/riwitalent/groups");
    }
}
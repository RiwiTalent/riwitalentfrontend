using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using riwitalentfrontend.Models;

namespace riwitalentfrontend.Services;

public class GroupCodersServices
{
    private readonly HttpClient _client;
    private readonly NavigationManager _navigation;

    public GroupCodersServices(HttpClient client, NavigationManager navigation)
    {
        _client = client;
        _navigation = navigation;

    }

    public async Task<CodersInGroup> GetCodersInGroupAsync(string key)
    {
        var response = await _client.GetFromJsonAsync<CodersInGroup>($"https://backend-riwitalentfrontend.alent-9pv2.onrender.com/riwitalentfrontend.alent/groupdetails/{key}");
        return response;
    }
    

    public async Task AuthenticationExternalAsync(AuthExternalRequest login, string key)
    {
        var loginExternalResponse = await _client.PostAsJsonAsync<AuthExternalRequest>(
            $"https://backend-riwitalentfrontend.alent-9pv2.onrender.com/riwitalentfrontend.alent/validationexternal",
            login
        );

        if (loginExternalResponse.IsSuccessStatusCode)
        {
            _navigation.NavigateTo($"/HomeClient/{key}");
        }
        else
        {
            Console.WriteLine($"Error: {loginExternalResponse.StatusCode}");
        }
    }
}

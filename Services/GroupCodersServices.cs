using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using riwi.Models;

namespace riwi.Services;

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
        var response = await _client.GetFromJsonAsync<CodersInGroup>($"https://backend-riwitalent.onrender.com/riwitalent/groupdetails/{key}");
        return response;
    }
    

    public async Task AuthenticationExternalAsync(AuthExternalRequest login, string key)
    {
        var loginExternalResponse = await _client.PostAsJsonAsync<AuthExternalRequest>(
            $"https://backend-riwitalent.onrender.com/riwitalent/validationexternal",
            login
        );

        if (loginExternalResponse.IsSuccessStatusCode)
        {
            _navigation.NavigateTo($"/HomeExterno/{key}");
        }
        else
        {
            Console.WriteLine($"Error: {loginExternalResponse.StatusCode}");
        }
    }
}
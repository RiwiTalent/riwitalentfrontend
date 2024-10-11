using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using riwitalentfrontend.Models;

namespace riwitalentfrontend.Services;

    public class GroupCodersServices
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigation;

        public GroupCodersServices(HttpClient httpClient, NavigationManager navigation)
        {
            _httpClient = httpClient;
            _navigation = navigation;

        }

    public async Task<CodersInGroup> GetCodersInGroupAsync(string key)
    {
        var response = await _httpClient.GetFromJsonAsync<CodersInGroup>($"https://backend-riwitalentfrontend.alent-9pv2.onrender.com/riwitalentfrontend.alent/groupdetails/{key}");
        return response;
    }
    

    public async Task AuthenticationExternalAsync(AuthExternalRequest login, string key)
    {
        var loginExternalResponse = await _httpClient.PostAsJsonAsync<AuthExternalRequest>(
            $"https://backend-riwitalentfrontend.alent-9pv2.onrender.com/riwitalentfrontend.alent/validationexternal",
            login
        );

            if (loginExternalResponse.IsSuccessStatusCode)
            {
                _navigation.NavigateTo($"/HomeClient/{key}");
                return true; 
            }
            else
            {
                Console.WriteLine($"Error: {loginExternalResponse.StatusCode}");
                return false; 
            }
        }


        public async Task<Group> GetGroupInfoById(string groupId)
        {
            var response = await _httpClient.GetFromJsonAsync<Group>($"http://localhost:5113/group-details/{groupId}");

            if (response != null)
            {
                Console.WriteLine("Details successfully fetched");
            }
            else
            {
                Console.WriteLine("Error fetching details");
            }

            return response;
        }








    }

    using System.Net.Http.Json;
    using Microsoft.AspNetCore.Components;
    using riwi.Models;

    namespace riwi.Services;

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
            var response = await _httpClient.GetFromJsonAsync<CodersInGroup>($"https://backend-riwitalent-9pv2.onrender.com/groupdetails/{key}");
            return response;
        }
        

        public async Task<bool> AuthenticationExternalAsync(AuthExternalRequest login, string key)
        {
            var loginExternalResponse = await _httpClient.PostAsJsonAsync<AuthExternalRequest>(
                $"http://localhost:5113/validation-external",
                login
            );

            if (loginExternalResponse.IsSuccessStatusCode)
            {
                // _navigation.NavigateTo($"/HomeExterno/{key}");
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
            var response = await _httpClient.GetFromJsonAsync<Group>($"https://backend-riwitalent-9pv2.onrender.com/group-details/{groupId}");
            return response;
        }







    }

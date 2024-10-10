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
            var response = await _httpClient.GetFromJsonAsync<CodersInGroup>($"https://backend-riwitalent-9pv2.onrender.com/groupdetails/{key}");
            return response;
        }
        

        public async Task<bool> AuthenticationExternalAsync(AuthExternalRequest login)
        {
            var loginExternalResponse = await _httpClient.PostAsJsonAsync<AuthExternalRequest>
                ($"http://localhost:5113/validation-external?Id={login.GroupId}&AssociateEmail={login.AssociateEmail}&Key={login.Key}",
                login);



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

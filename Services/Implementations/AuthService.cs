
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using riwitalentfrontend.Models;
using Microsoft.AspNetCore.Components.Authorization;
using riwitalentfrontend.Services.Interfaces;
using System.Net.Http.Headers;
using Blazored.SessionStorage;


namespace riwitalentfrontend.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private AuthenticationStateProvider _authenticationStateProvider;
        private readonly ISessionStorageService _sessionStorage;

        // Constructor corregido sin la coma final
        public AuthService(HttpClient httpClient, IJSRuntime jsRuntime, AuthenticationStateProvider authenticationStateProvider, ISessionStorageService sessionStorage)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
            _authenticationStateProvider = authenticationStateProvider;
            _sessionStorage = sessionStorage;
        }

        // Obtiene el endpoint y recibe los parametros enviados desde el login verificandolos
        public async Task<bool> Login(string email, string password)
        {
            var loginData = new { Email = email, Password = password };
            // Llama a Firebase Auth desde JS
            try
            {
                var token = await _jsRuntime.InvokeAsync<string>("firebaseAuth.signInWithEmailAndPassword", loginData.Email, loginData.Password);

                Console.WriteLine(token);

                await LoginBack(token);

                return true;
            }
            catch (JSException jsEx)
            {
                return false;
            }
        }
        
        // Funcion para guardar cookies llamando la funcion de js y asignando el token
        private async Task SaveTokenInCookies(string token)
        {
            await _jsRuntime.InvokeVoidAsync("setTokenInCookies", token);
        }

        // Funcion para leer el token desde cookie llamando la funcion de js
        public async Task<string> GetToken()
        {
            var token = await _jsRuntime.InvokeAsync<string>("getCookie", "authToken");

            if(token == null || token == ""){
                return "nada";
            }

            return token;
        }

        // Funcion para cerrar sesion eliminando el token de la cookie llamando la funcion de js
        public async Task Logout()
        {
            await _jsRuntime.InvokeAsync<string>("firebaseAuth.signOut");

              // Eliminar el correo del SessionStorage
            await _sessionStorage.RemoveItemAsync("userEmail");

            await _jsRuntime.InvokeVoidAsync("deleteTokenFromCookies");
        }

        private async Task LoginBack(string tokenFirebase){
            string url = $"http://localhost:5113/login/{tokenFirebase}";

            HttpResponseMessage response = await _httpClient.PostAsync(url, null);

            if(response.IsSuccessStatusCode){
                ResponseJwt responseBody = await response.Content.ReadFromJsonAsync<ResponseJwt>();

                SaveTokenInCookies(responseBody.token);
            }
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
    }
}

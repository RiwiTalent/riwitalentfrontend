using System.Net.Http.Json;
using Microsoft.JSInterop;
using RTFrontend.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Text.Json;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using RTFrontend.Services.Interfaces;


namespace RTFrontend.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private AuthenticationStateProvider _authenticationStateProvider;
        private readonly ISessionStorageService _sessionStorage;
        private readonly NavigationManager _navigation;

        // Constructor corregido sin la coma final
        public AuthService(HttpClient httpClient, IJSRuntime jsRuntime,
            AuthenticationStateProvider authenticationStateProvider, ISessionStorageService sessionStorage,
            NavigationManager navigation)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
            _authenticationStateProvider = authenticationStateProvider;
            _sessionStorage = sessionStorage;
            _navigation = navigation;

        }

        // Obtiene el endpoint y recibe los parametros enviados desde el login verificandolos
        public async Task<bool> Login(string email, string password)
        {
            var loginData = new { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("https://backend-riwitalent-9pv2.onrender.com/login", loginData);

            if (response.IsSuccessStatusCode)
            {
                // Guardo el token y asigno autenticación usando authenticationStateProvider
                var token = await response.Content.ReadAsStringAsync();
                await SaveTokenInCookies(token);
                var authenticationExt = (CustomAuthStateProvider)_authenticationStateProvider;
                authenticationExt.ActualizarEstadoAutenticacion(token);

                return true;
            }
            return false;
        }
        
        // Funcion para guardar cookies llamando la funcion de js y asignando el token
        public async Task SaveTokenInCookies(string token)
        {
            await _jsRuntime.InvokeVoidAsync("setTokenInCookies", token);
        }

        // Funcion para leer el token desde cookie llamando la funcion de js
        public async Task<string> GetToken()
        {
            var token = await _jsRuntime.InvokeAsync<string>("getCookie", "authToken");
            return token;
        }

        // Funcion para cerrar sesion eliminando el token de la cookie llamando la funcion de js
        public async Task Logout()
        {
            await _jsRuntime.InvokeVoidAsync("deleteTokenFromCookies");

              // Eliminar el correo del SessionStorage
            await _sessionStorage.RemoveItemAsync("userEmail");
        }
        
        public async Task SaveStorage<T>(ISessionStorageService sessionStorageService, string key, T item)where T:class
        {
            var itemJson = JsonSerializer.Serialize(item);
            await sessionStorageService.SetItemAsStringAsync(key, itemJson);
        }

        public async Task<T?> GetStorage<T>(ISessionStorageService sessionStorageService, string key)where T:class
        {
            var itemJson = await sessionStorageService.GetItemAsStringAsync(key);

            if (itemJson != null)
            {
                var item = JsonSerializer.Deserialize<T>(itemJson);
                return item;
            }else{
                return null;
            }
        }

        public async Task AuthenticationExternalAsync(AuthExternalRequest login, string key)
        {
            var loginExternalResponse = await _httpClient.PostAsJsonAsync<AuthExternalRequest>(
                $"https://backend-riwitalent-9pv2.onrender.com/riwitalent/validationexternal",
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
}
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using riwi.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using Blazored.SessionStorage;


namespace riwi.Services
{
    public class AuthService
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
            var response = await _httpClient.PostAsJsonAsync("https://backend-riwitalent-9pv2.onrender.com/login", loginData);

            if (response.IsSuccessStatusCode)
            {
                // Guardo el token y asigno autenticación usando authenticationStateProvider
                var token = await response.Content.ReadAsStringAsync();
                await SaveTokenInCookies(token);
                var authenticationExt = (CustomAuthStateProvider)_authenticationStateProvider;
                await authenticationExt.ActualizarEstadoAutenticacion(token);

                return true;
            }
            return false;
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
            return token;
        }

        // Funcion para cerrar sesion eliminando el token de la cookie llamando la funcion de js
        public async Task Logout()
        {
            await _jsRuntime.InvokeVoidAsync("deleteTokenFromCookies");

              // Eliminar el correo del SessionStorage
            await _sessionStorage.RemoveItemAsync("userEmail");
        }
    }
}

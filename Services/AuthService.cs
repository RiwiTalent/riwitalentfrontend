using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using riwi.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;


namespace riwi.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(HttpClient httpClient, IJSRuntime jsRuntime, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _jsRuntime= jsRuntime;
            _authenticationStateProvider = authenticationStateProvider;
        }

        // Obtiene el endpoint y recibe los parametros enviados desde el login verificandolos
        public async Task<bool> Login(string email, string password)
        {
            var LoginData = new { Email = email, Password = password};
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5113/riwitalent/login", LoginData);

            if(response.IsSuccessStatusCode)
            {
                // Cuardo el token y asigno autenticacion usando authenticationStateProvider
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
        }
    }
}
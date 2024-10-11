using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace riwitalentfrontend.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private ClaimsPrincipal _usuarioActual = new ClaimsPrincipal(new ClaimsIdentity());
        public CustomAuthStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ActualizarEstadoAutenticacion(string token)
        {
            // Aquí codificamos el token y especificamos que esperamos que el token es vacio
            var authenticatedUser = !string.IsNullOrEmpty(token)
                ? new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim("jwt", token) }, "jwt"))
                : new ClaimsPrincipal(new ClaimsIdentity());

            // Actualiza el estado de autenticación
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(authenticatedUser)));
        }

        // Obtiene el token desde la cookie llamando las funciones de js y puede verificarse si es autorizado o no
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _jsRuntime.InvokeAsync<string>("getCookie", "authToken");
            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var identity = new System.Security.Claims.ClaimsIdentity();
            var user = new System.Security.Claims.ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }

        // Asignando parametros de la autenticacion de el usuario
        public void NotifyUserAuthentication(string token)
        {
            var identity = new System.Security.Claims.ClaimsIdentity();
            var authenticatedUser = new System.Security.Claims.ClaimsPrincipal(identity);
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

            NotifyAuthenticationStateChanged(authState);
        }

        // funcion para cerrar sesion eliminando el token de la cookie y quitando la autorizacion 
        public void NotifyUserLogout()
        {
            var anonymousUser = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));

            NotifyAuthenticationStateChanged(authState);
        }

    }
}
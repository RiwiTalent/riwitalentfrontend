using Blazored.SessionStorage;
using riwitalentfrontend.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace riwitalentfrontend.Services
{
    public class AuthenticacionExtension : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sesionStorage;
        private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthenticacionExtension(ISessionStorageService sessionStorage)
        {
            _sesionStorage = sessionStorage;
        }

        public async Task ActualizarEstadoAutenticacion(Coder? sesionUsuario)
        {   
            Console.WriteLine($"Nombre: {sesionUsuario.FirstName}, Email: {sesionUsuario.Email}");

            ClaimsPrincipal claimsPrincipal;
            Console.WriteLine(sesionUsuario);
            if (sesionUsuario != null)
            {
                // Agregar las Claims relevantes para la autenticación
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, sesionUsuario.FirstName),
                    new Claim(ClaimTypes.Email, sesionUsuario.Email),
                    // Agrega cualquier otra Claim relevante para tu lógica de autorización
                }, "JwtAuth"));
                
                // Guardar la sesión del usuario en el almacenamiento
                await _sesionStorage.GuardarStorage("sesionUsuario", sesionUsuario);
            }
            else
            {
                // Si no hay usuario, establecer un ClaimsPrincipal vacío
                claimsPrincipal = _sinInformacion;
                await _sesionStorage.RemoveItemAsync("sesionUsuario");
            }

            // Notificar el cambio en el estado de autenticación
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _sesionStorage.ObtenerStorage<User>("userEmail");

            if (sesionUsuario == null)
                return await Task.FromResult(new AuthenticationState(_sinInformacion));
            
            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    
                },"JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimPrincipal));
        }
    }
}
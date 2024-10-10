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

        public async Task ActualizarEstadoAutenticacion(User? sesionUsuario)
        {
            ClaimsPrincipal claimsPrincipal;
            Console.WriteLine(sesionUsuario);
            if (sesionUsuario != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    
                },"JwtAuth"));
                await _sesionStorage.GuardarStorage("sesionUsuario",sesionUsuario);
            }
            else{
                claimsPrincipal = _sinInformacion;
                await _sesionStorage.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _sesionStorage.ObtenerStorage<User>("sesionUsuario");

            if (sesionUsuario == null)
                return await Task.FromResult(new AuthenticationState(_sinInformacion));
            
            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    
                },"JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimPrincipal));
        }
    }
}
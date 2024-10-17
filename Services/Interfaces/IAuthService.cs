using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using riwitalentfrontend.Models;


namespace riwitalentfrontend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(string? email, string? password);
        
        Task<string> GetToken();
        Task Logout();
        // Task SaveStorage<T>( ISessionStorageService sessionStorageService, string key, T item) where T : class;
        // Task<T?> GetStorage<T>( ISessionStorageService sessionStorageService, string key) where T : class;
        Task<bool> AuthenticationExternalAsync(AuthExternalRequest login);
        // Task ActualizarEstadoAutenticacion(User? sesionUsuario);
        // Task<AuthenticationState> AuthenticationStateAsync();
    }
}
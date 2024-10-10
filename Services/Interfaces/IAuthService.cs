using Blazored.SessionStorage;
using riwitalentfrontend.Models;


namespace riwitalentfrontend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(string? email, string? password);
        Task SaveTokenInCookies(string token);
        Task<string> GetToken();
        Task Logout();
        Task SaveStorage<T>( ISessionStorageService sessionStorageService, string key, T item) where T : class;
        Task<T?> GetStorage<T>( ISessionStorageService sessionStorageService, string key) where T : class;
        Task AuthenticationExternalAsync(AuthExternalRequest login, string key);

    }
}
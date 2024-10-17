using System.Net.Http.Headers;
using Microsoft.JSInterop;

namespace riwitalentfrontend.Services
{
    public class TokenHandler : DelegatingHandler
    {
        private readonly IJSRuntime _jsRuntime;

        public TokenHandler(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        // Este metodo sirve para establecer el token como cabecera de la autenticacion
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Obtener el token de las cookies
            var token = await _jsRuntime.InvokeAsync<string>("getCookie", "authToken");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
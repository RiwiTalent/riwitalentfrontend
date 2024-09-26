using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace riwi.Services
{
    public class TokenHandler : DelegatingHandler
    {
        private readonly IJSRuntime _jsRuntime;

        public TokenHandler(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        // Esta funcion sirve para establecer el token como cabecera de la autenticacion
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
namespace riwitalentfrontend.Services.Implementations
{
    public class CustomHttpHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                // Enviar la solicitud
                var response = await base.SendAsync(request, cancellationToken);

                // Verificar si hay errores en la respuesta
                if (!response.IsSuccessStatusCode)
                {
                    // Manejar errores de estado HTTP aquí (por ejemplo, 400, 500, etc.)
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"HTTP Erroe: {response.StatusCode}, Details: {errorContent}");
                }

                return response;
            }
            catch (HttpRequestException ex)
            {
                // Manejo de errores de conexion
                Console.WriteLine($"HttpRequestException {ex.Message}");
                throw new HttpRequestException("Error de conexión al servidor. Intente nuevamente más tarde.", ex);
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                Console.WriteLine($"General Exception: {ex.Message}");
                throw new Exception("Ocurrió un error inesperado. Intente nuevamente más tarde.", ex);
            }
        }
    }
}
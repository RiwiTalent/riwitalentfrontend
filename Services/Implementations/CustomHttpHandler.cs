namespace riwitalentfrontend.Services.Implementations
{
    public class CustomHttpHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {

                var response = await base.SendAsync(request, cancellationToken);


                if (!response.IsSuccessStatusCode)
                {
                   
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"HTTP Erroe: {response.StatusCode}, Details: {errorContent}");
                }

                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HttpRequestException {ex.Message}");
                throw new HttpRequestException("Error de conexión al servidor. Intente nuevamente más tarde.", ex);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"General Exception: {ex.Message}");
                throw new Exception("Ocurrió un error inesperado. Intente nuevamente más tarde.", ex);
            }
        }
    }
}
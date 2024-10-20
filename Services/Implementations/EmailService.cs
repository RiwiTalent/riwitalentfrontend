using riwitalentfrontend.Models;
using riwitalentfrontend.Services.Interfaces;



namespace riwitalentfrontend.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient _httpClient;

        public EmailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SendEmailCompany(string groupId)
        {
            var response = await _httpClient.PostAsync($"http://localhost:5113/email/company-process?id={groupId}", null);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SendEmailTest(string groupId)
        {
            try
            {
                var response = await _httpClient.PostAsync($"http://localhost:5113/email/accept-terms?Id={groupId}", null);
                response.EnsureSuccessStatusCode(); // Lanza una excepción si no es exitoso

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
                return false;
            }
        }
    }

    
}

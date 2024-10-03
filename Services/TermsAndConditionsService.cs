    using System.Net.Http.Json;
    using riwi.Models;
    using Microsoft.AspNetCore.Components;

    namespace riwi.Services
    {
        public class TermsAndConditionsService
        {
            private readonly HttpClient _client;
            private readonly NavigationManager _navigation;

            public TermsAndConditionsService(HttpClient client, NavigationManager navigation)
            {
                _client = client;
                _navigation = navigation;
            }

            // Método para aceptar los términos y crear el registro en la base de datos
            public async Task<bool> AcceptTermsAsync(TermAndCondition newTerms)
            {
                var response = await _client.PostAsJsonAsync("http://localhost:5113/terms", newTerms);

                if (response.IsSuccessStatusCode)
                {
                    return true; // Retorna true si la creación fue exitosa
                }
                else
                {
                    Console.WriteLine($"Error creating terms: {response.StatusCode}");
                    return false; // Retorna false si falló
                }
            }
        }
    }

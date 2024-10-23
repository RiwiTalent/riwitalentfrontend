using System.Net.Http.Json;
using riwitalentfrontend.Models;
using Microsoft.AspNetCore.Components;

namespace riwitalentfrontend.Services
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
            // Usar la URL global desde GlobalConfig
            var response = await _client.PostAsJsonAsync($"{GlobalConfig.ApiUrl}terms?10IsActive={newTerms.IsActive}&Accepted={newTerms.Accepted}&Version=1&GroupId={newTerms.GroupId}&AcceptedEmail={newTerms.AcceptedEmail}&CreatorEmail={newTerms.CreatorEmail}", newTerms);

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
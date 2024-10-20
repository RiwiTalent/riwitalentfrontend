using System.Net.Http.Json;
using riwitalentfrontend.Services.Interfaces;
using riwitalentfrontend.Models;
using riwitalentfrontend.Models.DTOs;



namespace riwitalentfrontend.Services.Implementations
{
    // Servicio para interactuar con la API de coders
    public class CoderService : ICoderService
    {
        // Inyección de HttpClient para realizar peticiones HTTP
        private readonly HttpClient _httpClient;

        public CoderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para obtener una lista de coders desde la API
        public async Task<List<Coder>> GetCodersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Coder>>(
                "https://backend-riwitalent-9pv2.onrender.com/coders");
        }

        
        // Metodo para actualizar un Coder :C pendiente de refactorizar 
        public async Task<bool> UpdateCoderAsync(Coder coder)
        {
            // Construir la URL utilizando el método BuildCoderLink
            var url = BuildCoderLink(coder);

            // Realizar la llamada PUT al backend
            var response = await _httpClient.PutAsync(url, null);
            return response.IsSuccessStatusCode;
        }

// Método privado para construir el enlace
        private string BuildCoderLink(Coder coder)
        {
            return $"https://backend-riwitalent-9pv2.onrender.com/coders?" +
                   $"Id={Uri.EscapeDataString(coder.Id)}&" +
                   $"FirstName={Uri.EscapeDataString(coder.FirstName)}&" +
                   $"SecondName={Uri.EscapeDataString(coder.SecondName)}&" +
                   $"FirstLastName={Uri.EscapeDataString(coder.FirstLastName)}&" +
                   $"ProfessionalDescription={Uri.EscapeDataString(coder.ProfessionalDescription)}&" +
                   $"Age={coder.Age}&" +
                   $"Email={Uri.EscapeDataString(coder.Email)}&" +
                   $"Age={coder.Age}&" +
                   $"Photo={Uri.EscapeDataString(coder.Photo)}&" +
                   $"Phone={Uri.EscapeDataString(coder.Phone)}&" +
                   $"AssessmentScore={coder.AssessmentScore}&" +
                   $"Cv={Uri.EscapeDataString(coder.Cv)}&" +
                   $"Status={Uri.EscapeDataString(coder.Status)}&" +
                   $"Stack={Uri.EscapeDataString(coder.Stack)}";
                   // $"GroupId={Uri.EscapeDataString(coder.GroupId.ToString())}";
                   // $"StandarRiwi={Uri.EscapeDataString(coder.StandarRiwi.ToString())}&" + // Agrega el estándar
                   // $"Skills={Uri.EscapeDataString(())} &" + // Agrega habilidades
                   // $"LanguageSkills={Uri.EscapeDataString(coder.LanguageSkills.Language)}"; // Agrega habilidades lingüísticas
        }


        public async Task<List<Coder>?> FilterCodersBySkillsAsync(List<string> skills)
        {
            var queryString = string.Join("&", skills.Select(skill => $"skills={Uri.EscapeDataString(skill)}"));
            var url = $"http://localhost:5113/coders?{queryString}";
            Console.WriteLine($"Request URL: {url}");
            return await _httpClient.GetFromJsonAsync<List<Coder>>(url);

        }

        public Task<bool> UploadPhoto(string coderId, Stream stream, string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCodersAsync(string coderId)
        {

            try
            {
                var response = await _httpClient.DeleteAsync($"http://localhost:5113/coders/{coderId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al desactivar coder: {ex.Message}");
                return false;
            }
        }

        public async Task<Coder> GetCoderByIdAsync(string coderId)
        {
            // Realiza la solicitud GET para obtener los detalles del coder
            Console.WriteLine("entra a get coder BY id");
            var response = await _httpClient.GetFromJsonAsync<Coder>($"http://localhost:5113/coder/{coderId}");

            if (response != null)
            {
                // Mensaje de éxito si el coder fue encontrado
                Console.WriteLine("Coder details successfully fetched");
            }
            else
            {
                // Mensaje de error si no se pudo obtener el coder
                Console.WriteLine("Error al obtener coder por Id");
            }

            return response; // Retorna el coder o null si no se encontró
        }

        public async Task<bool> CodersGroupedAsync(DataDto data)
        {

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5113/coders/grouped", data);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Coders agregados correctamente al grupo.");
            }
            else
            {
                Console.WriteLine($"Error al agregar los coders: {response.StatusCode}");
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CoderSelectedAsync(DataDto data)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5113/coders/selected", data);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Coders seleccionados correctamente al grupo.");
            }
            else
            {
                Console.WriteLine($"Error al agregar los coders: {response.StatusCode}");
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UploadCoderPhoto(string coderId, Stream stream, string fileName)
        {
            if (stream == null || stream.Length == 0)
            {
                throw new ArgumentException("No file uploaded", nameof(stream));
            }

            using var content = new MultipartFormDataContent();

            var fileContent = new StreamContent(stream);
            content.Add(fileContent, "file", fileName);

            var response = await _httpClient.PostAsync($"http://localhost:5113/coder/photo/{coderId}", content);
            

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se subió de manera correcta la foto");
                return true;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine(coderId);

                throw new Exception($"Error al cargar la foto: {response.StatusCode}, Detalle: {errorMessage}");
            }
        }
    }
}

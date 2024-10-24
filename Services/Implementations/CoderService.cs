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
                $"{GlobalConfig.ApiUrl}coders");
        }

        // Método para actualizar un Coder: pendiente de refactorizar 
        public async Task<bool> UpdateCoderAsync(Coder coder)
        {
            // Construir la URL utilizando el método BuildCoderLink
            var url = BuildCoderLink(coder);

            // Realizar la llamada PUT al backend
            var response = await _httpClient.PutAsync(url, null);
            return response.IsSuccessStatusCode;
        }

        // Lógica para crear un coder desde la base de datos o API
        public async Task<bool> AddCoderAsync(CoderAddDto coderAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5113/coders", coderAddDto);
            return response.IsSuccessStatusCode;
        }

// Método privado para construir el enlace
        // Método privado para construir el enlace
        private string BuildCoderLink(Coder coder)
        {
            return $"{GlobalConfig.ApiUrl}coders?" +
                   $"Id={Uri.EscapeDataString(coder.Id)}&" +
                   $"FirstName={Uri.EscapeDataString(coder.FirstName)}&" +
                   $"SecondName={Uri.EscapeDataString(coder.SecondName)}&" +
                   $"FirstLastName={Uri.EscapeDataString(coder.FirstLastName)}&" +
                   $"ProfessionalDescription={Uri.EscapeDataString(coder.ProfessionalDescription)}&" +
                   $"Age={coder.Age}&" +
                   $"Email={Uri.EscapeDataString(coder.Email)}&" +
                   $"Age={coder.Age}&" +
                   $"Photo={coder.Photo}&" +
                   $"Photo={coder.Photo}&" +
                   $"Phone={Uri.EscapeDataString(coder.Phone)}&" +
                   $"AssessmentScore={coder.AssessmentScore}&" +
                   $"Cv={Uri.EscapeDataString(coder.Cv)}&" +
                   $"Status={Uri.EscapeDataString(coder.Status)}&" +
                   $"Stack={Uri.EscapeDataString(coder.Stack)}";
                   // Agregar más campos si es necesario
        }

        public async Task<List<Coder>?> FilterCodersBySkillsAsync(List<string> skills)
        {
            var queryString = string.Join("&", skills.Select(skill => $"skills={Uri.EscapeDataString(skill)}"));
            var url = $"{GlobalConfig.ApiUrl}coders?{queryString}";
            Console.WriteLine($"Request URL: {url}");
            return await _httpClient.GetFromJsonAsync<List<Coder>>(url);
        }

        public async Task<List<Coder>?> GetCodersByLanguage(List<string> languageLevels)
        {
            // Verifica si la lista de niveles de idioma no está vacía
            if (languageLevels == null || !languageLevels.Any())
            {
                return new List<Coder>();
            }

            // Construcción del queryString
            var queryString = string.Join("&", languageLevels.Select(level => $"levels={Uri.EscapeDataString(level)}"));
            
            // Construcción de la URL final con el queryString
            var url = $"{GlobalConfig.ApiUrl}coders/languages?{queryString}&language=English";

            Console.WriteLine($"Request URL: {url}");
            
            // Realiza la petición HTTP
            return await _httpClient.GetFromJsonAsync<List<Coder>>(url);
        }

        public async Task<bool> DeleteCodersAsync(string coderId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{GlobalConfig.ApiUrl}coders?id={coderId}");
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
            var response = await _httpClient.GetFromJsonAsync<Coder>($"{GlobalConfig.ApiUrl}coder/{coderId}");

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
            var response = await _httpClient.PostAsJsonAsync($"{GlobalConfig.ApiUrl}coders/grouped", data);

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
            var response = await _httpClient.PostAsJsonAsync($"{GlobalConfig.ApiUrl}coders/selected", data);

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

            var response = await _httpClient.PostAsync($"{GlobalConfig.ApiUrl}coder/photo/{coderId}", content);
            
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

        public async Task<bool> UploadCvCoder(string coderId, Stream stream, string fileName)
        {
            if (stream == null || stream.Length == 0)
            {
                throw new ArgumentException("No file uploaded", nameof(stream));
            }

            using var content = new MultipartFormDataContent();

            var fileContent = new StreamContent(stream);
            content.Add(fileContent, "file", fileName);

            var response = await _httpClient.PostAsync($"{GlobalConfig.ApiUrl}upload-pdf/{coderId}", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Se subió de manera correcta la Cv");
                return true;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine(coderId);
                throw new Exception($"Error al cargar Cv: {response.StatusCode}, Detalle: {errorMessage}");
            }
        }

        public async Task<string> DownloadCv(string coderId)
        {
            var response = await _httpClient.GetAsync($"{GlobalConfig.ApiUrl}{coderId}/cv");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine(coderId);
                throw new Exception($"Error al cargar Cv: {response.StatusCode}, Detalle: {errorMessage}");
            }
        }
    }
}


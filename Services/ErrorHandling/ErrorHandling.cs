namespace riwitalentfrontend.Services;

public static class ErrorHandling
{
    public static async Task ExecuteWithErrorHandlingAsync(Func<Task> operation, Action<string> onError)
    {
        try
        {
            await operation();
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine($"Error: {httpEx.Message}");
            onError($"Error de conexión o HTTP: {httpEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            onError($"Error de conexión o HTTP: {ex.Message}");
        }
    }
}
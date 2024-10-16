using Microsoft.JSInterop;

namespace riwitalentfrontend;

public class FirebaseAuthService{

    private readonly IJSRuntime _jsRuntime;

    public FirebaseAuthService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<string> SignInWithEmailAndPassword(string email, string password)
    {
        try
        {
            // Llamar a la función JavaScript de Firebase para iniciar sesión
            var token = await _jsRuntime.InvokeAsync<string>("firebaseAuth.signInWithEmailAndPassword", email, password);
            return token;
        }
        catch (JSException jsEx)
        {
            // Atrapar la excepción de Firebase y propagar el mensaje de error
            // Puedes procesar el error aquí o pasarlo tal cual para mostrarlo en el componente
            return "Error";
        }
    }

    public async Task<string> SignOut()
    {
        return await _jsRuntime.InvokeAsync<string>("firebaseAuth.signOut");
    }
}
using Microsoft.JSInterop;
using MudBlazor;
using riwitalentfrontend.Theme;

public class ThemeService
{
    public event Action OnThemeChanged;
    
    private readonly IJSRuntime _jsRuntime;

    private readonly MudTheme _lightTheme = new MudTheme()
    {
        PaletteLight = CustomMudTheme.PaletteLight,
        Typography = CustomMudTheme.TypographyRiwi
    };

    private readonly MudTheme _darkTheme = new MudTheme()
    {
        PaletteDark = CustomMudTheme.PaletteDark,
        Typography = CustomMudTheme.TypographyRiwi
    };
    

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    public async Task<MudTheme> GetThemeAsync()
    {
        // Obtener el estado del modo oscuro del almacenamiento local
        var isDarkMode = await GetDarkModeAsync();
        return isDarkMode ? _darkTheme  : _lightTheme;
    }

    public async Task<bool> GetDarkModeAsync()
    {
        // Lógica para obtener el estado del modo oscuro desde el almacenamiento local
        var storedMode = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "isDarkMode");
        return bool.TryParse(storedMode, out var isDarkMode) && isDarkMode;
    }

    public async Task SetDarkModeAsync(bool isDarkMode)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "isDarkMode", isDarkMode.ToString());
    }
}
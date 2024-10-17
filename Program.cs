// Espacios de nombres de Microsoft
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

// Espacios de nombres de terceros
using MudBlazor.Services;
using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using Blazored.SessionStorage;
using MudBlazor;

// Espacios de nombres de la aplicación
using riwitalentfrontend;
using riwitalentfrontend.Services.Implementations;
using riwitalentfrontend.Services.Interfaces;
using riwitalentfrontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Agregar componentes raíz
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configurar HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://backend-riwitalent-9pv2.onrender.com/") });

// Servicios personalizados
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<ICoderService, CoderService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<CustomHttpHandler>();
builder.Services.AddTransient<CoderService>();
builder.Services.AddTransient<GroupService>();

// Configuración del HttpClient para servicios específicos
builder.Services.AddHttpClient<IGroupService, GroupService>(client =>
{
    client.BaseAddress = new Uri("https://backend-riwitalent-9pv2.onrender.com/");
})
.AddHttpMessageHandler<CustomHttpHandler>(); 

// Servicios de estado y almacenamiento
builder.Services.AddBlazoredSessionStorage();

// Configuración de MudBlazor con ajustes adicionales para Snackbars
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

// Servicios de interfaz de usuario - MudBlazor y BlazoredModal
builder.Services.AddMudServices();  // Ya está añadido con la configuración de Snackbar
builder.Services.AddBlazoredModal();

// Servicios de seguridad y autenticación
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<AuthService>();

// SweetAlert2 para alertas personalizadas
builder.Services.AddScoped<AlertService>();
builder.Services.AddSweetAlert2();

// Construir y ejecutar la aplicación
await builder.Build().RunAsync();

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
using Microsoft.Extensions.DependencyInjection;

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
builder.Services.AddScoped<IEmailService, EmailService>();
// builder.Services.AddScoped<AuthService>();
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

// Servicios de interfaz de usuario - MudBlazor
builder.Services.AddMudServices();
builder.Services.AddBlazoredModal();

// Servicios de seguridad y autenticación
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<TermsAndConditionsService>();
builder.Services.AddScoped<FirebaseAuthService>();


// SweetAlert2 para alertas
builder.Services.AddScoped<AlertService>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();

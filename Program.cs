using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using riwi;
using MudBlazor.Services;
using riwi.Services;
using Blazored.Modal;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using riwi.Extensiones;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5113/") });
builder.Services.AddTransient<CoderService>();

//Jhoan
builder.Services.AddBlazoredModal();
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider,AuthenticacionExtension>();
builder.Services.AddAuthorizationCore();

//Service to MudBlazor
builder.Services.AddMudServices();

await builder.Build().RunAsync();

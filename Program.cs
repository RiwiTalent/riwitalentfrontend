using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using riwi;
using MudBlazor.Services;
using riwi.Services;
using Blazored.Modal;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5113/") });
builder.Services.AddTransient<CoderService>();

builder.Services.AddBlazoredModal();

//Service to MudBlazor
builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider,AuthenticacionExtension>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();

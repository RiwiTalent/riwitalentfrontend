using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using riwi;
using MudBlazor.Services;
using riwi.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Authorization;
using CurrieTechnologies.Razor.SweetAlert2;
using Blazored.SessionStorage;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredSessionStorage();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5113/") });
builder.Services.AddTransient<CoderService>();
builder.Services.AddTransient<GroupCodersServices>();


// Sweet alert services
builder.Services.AddScoped<AlertServices>();
builder.Services.AddSweetAlert2();

//Service to MudBlazor
builder.Services.AddMudServices();
builder.Services.AddBlazoredModal();

//Security services
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthStateProvider>();
builder.Services.AddScoped<AuthService>();


await builder.Build().RunAsync();

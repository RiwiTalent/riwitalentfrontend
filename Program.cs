using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using riwitalentfrontend;
using MudBlazor.Services;
using riwitalentfrontend.Services;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Authorization;
using CurrieTechnologies.Razor.SweetAlert2;
using Blazored.SessionStorage;
using Microsoft.Extensions.DependencyInjection;
using riwitalentfrontend.App;
using riwitalentfrontend;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredSessionStorage();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://backend-riwitalent-9pv2.onrender.com/") });
builder.Services.AddTransient<CoderService>();
builder.Services.AddTransient<GroupCodersServices>();

builder.Services.AddHttpClient<GroupsServices>(client =>
{
    client.BaseAddress = new Uri("https://backend-riwitalent-9pv2.onrender.com/");
});
// builder.Services.AddHttpClient<GroupsServices>(client =>
// {
//     client.BaseAddress = new Uri(" https://backend-riwitalent-9pv2.onrender.com/riwitalent/");
// });


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
builder.Services.AddScoped<TermsAndConditionsService>();
builder.Services.AddScoped<FirebaseAuthService>();



await builder.Build().RunAsync();

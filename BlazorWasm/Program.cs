using BlazorWasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasm.Auth;
using BlazorWasm.Services;
using BlazorWasm.Services.Http;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<IWeatherService, HttpWeatherService>();

//AuthorizationPolicies.AddPolicies(builder.Services);


builder.Services.AddScoped(sp => new HttpClient());
builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri("https://localhost:7130") });

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();

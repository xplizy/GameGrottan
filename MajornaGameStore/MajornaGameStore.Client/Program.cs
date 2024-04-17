using Blazorise;
using Blazorise.Icons.FontAwesome;
using MajornaGameStore.Client;
using MajornaGameStore.Client.Services;
using MajornaGameStore.Client.Services.Authentication;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;
using MajornaGameStore.Shared.Models.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7190") });

builder.Services
    .AddScoped<ProductViewModel>()
    .AddScoped<CartViewModel>();

//TODO: Lägg till éfter 1345 Create HTTP client to make a call to backend
builder.Services.AddScoped<IPaymentHttpClient, PaymentHttpClient>();

builder.Services
    .AddSingleton<IClientCartService, ClientCartService>()
    .AddScoped<IClientProductService, ClientProductService>();

builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();


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

builder.Services.AddTransient<CookieHandler>();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();

builder.Services.AddScoped(
    sp => (IAccountManagement)sp.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:7207" ?? "http://localhost:5241") });

builder.Services.AddHttpClient(
        "Auth",
        opt => opt.BaseAddress = new Uri("https://localhost:7190" ?? "http://localhost:5102"))
    .AddHttpMessageHandler<CookieHandler>();

//TODO: Kan vara så att denna nedan stör ut autentisering. Testa o se
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7190") });

builder.Services
    .AddScoped<ProductViewModel>()
    .AddScoped<CartViewModel>();

//TODO: Lägg till éfter 1345 Create HTTP client to make a call to backend
builder.Services.AddScoped<IPaymentHttpClient, PaymentHttpClient>();

builder.Services
    .AddSingleton<IClientCartService, ClientCartService>()
    .AddScoped<IClientProductService, ClientProductService>()
    .AddScoped<IClientEventsService, ClientEventsService>()
    .AddScoped<IClientCartService, ClientCartService>();


builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();


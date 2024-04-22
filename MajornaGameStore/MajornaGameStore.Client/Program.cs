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

//builder.Services.AddScoped(sp =>
//    new HttpClient { BaseAddress = new Uri("https://majornaggapi.azurewebsites.net") });

//builder.Services.AddHttpClient(
//        "Auth",
//        opt => opt.BaseAddress = new Uri("https://majornaggapi.azurewebsites.net"))
//    .AddHttpMessageHandler<CookieHandler>();

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:7190") });

builder.Services.AddHttpClient(
        "Auth",
        opt => opt.BaseAddress = new Uri("https://localhost:7190"))
    .AddHttpMessageHandler<CookieHandler>();

//TODO: Kan vara så att denna nedan stör ut autentisering. Testa o se
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7190") });


builder.Services
    .AddScoped<ProductViewModel>()
    .AddScoped<EventsViewModel>()
    .AddScoped<EventDetailViewModel>()
    .AddScoped<CartViewModel>();

builder.Services.AddScoped<IPaymentHttpClient, PaymentHttpClient>();

builder.Services
    .AddSingleton<IClientCartService, ClientCartService>()
    .AddScoped<IClientProductService, ClientProductService>()
    .AddScoped<IClientEventsService, ClientEventsService>()
    .AddScoped<IClientCartService, ClientCartService>();


builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();


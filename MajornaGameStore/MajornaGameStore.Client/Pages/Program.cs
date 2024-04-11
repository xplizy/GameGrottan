using Blazorise;
using Blazorise.Icons.FontAwesome;
using MajornaGameStore.Client;
using MajornaGameStore.Client.Services;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using MajornaGameStore.Shared.Models.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7190") });

builder.Services.AddScoped<ProductViewModel>();

builder.Services
    .AddSingleton<ICartService, CartService>()
    .AddScoped<IClientProductService, ClientProductService>();


await builder.Build().RunAsync();


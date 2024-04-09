using MajornaGameStore.Api.Extensions;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.DataAccess.Sql;
using MajornaGameStore.DataAccess.Sql.Repositories;
using MajornaGameStore.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("majornaDbCloud");

builder.Services.AddDbContext<MajornaDbContext>(
    options =>
        options.UseSqlServer(connectionString));

builder.Services.AddScoped<MajornaDbContext>();

builder.Services
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<ITypeRepository, TypeRepository>()
    .AddScoped<IDeveloperRepository, DeveloperRepository>()
    .AddScoped<IPublisherRepository, PublisherRepository>()
    .AddScoped<IScreenshotRepository, ScreenshotRepository>()
    .AddScoped<ITagRepository, TagRepository>()
    .AddScoped<IDiscountRepository, DiscountRepository>()
    .AddScoped<IEventRepository, EventRepository>()
    .AddScoped<IEventTypeRepository, EventTypeRepository>()
    .AddScoped<IReviewRepository, ReviewRepository>();

builder.Services
    .AddScoped<ProductService>()
    .AddScoped<DiscountService>()
    .AddScoped<TagService>()
    .AddScoped<ProductTypeService>()
    .AddScoped<EventService>()
    .AddScoped<ProductTypeService>()
    .AddScoped<DeveloperService>()
    .AddScoped<PublisherService>()
    .AddScoped<ScreenshotService>()
    .AddScoped<TagService>()
<<<<<<<<< Temporary merge branch 1
    .AddScoped<ReviewService>();
=========
    .AddScoped<EventTypeService>();
>>>>>>>>> Temporary merge branch 2

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.MapLoadProductEndPoints();
app.MapProductEndPoints();
app.MapEventEndPoints();
app.MapEventTypeEndPoints();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

using MajornaGameStore.Api.Extensions;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Mongo;
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.DataAccess.Sql;
using MajornaGameStore.DataAccess.Sql.Repositories;
using MajornaGameStore.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Stripe;
using DiscountService = MajornaGameStore.DataAccess.Services.DiscountService;
using EventService = MajornaGameStore.DataAccess.Services.EventService;
using ProductService = MajornaGameStore.DataAccess.Services.ProductService;
using ReviewService = MajornaGameStore.DataAccess.Services.ReviewService;

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
    .AddScoped<IReviewRepository, ReviewRepository>()
    .AddScoped<IOrderRepository, OrderRepository>();

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
    .AddScoped<ReviewService>()
    .AddScoped<EventTypeService>()
    .AddScoped<IOrderService, OrderService>();


StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

//add cors for no errors later on
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

//StripeConfiguration.ApiKey = "sk_test_51P1o0CALQne3zawOR30h5V9cqOtm7GK7l4t5HA6jHdVlkg8tyBiiqzjmUI6prlXhArha19lUxUq3jEBp9Ro531nH00bgxGxZqv";

//var options = new PaymentIntentCreateOptions
//{
//    Amount = 500,
//    Currency = "gbp",
//    PaymentMethod = "pm_card_se",
//};
//var service = new PaymentIntentService();
//service.Create(options);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//enligt instruktioner so that asp.net can activate these services
app.UseCors();
app.UseRouting();
app.MapControllers();

app.UseHttpsRedirection();

//app.MapLoadProductEndPoints();
app.MapProductEndPoints();
app.MapEventEndPoints();
app.MapEventTypeEndPoints();
app.MapOrderEndPoints();

app.Run();

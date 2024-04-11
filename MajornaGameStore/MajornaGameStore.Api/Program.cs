using MajornaGameStore.Api.Extensions;
using MajornaGameStore.Api.Stripe;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Mongo;
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.DataAccess.Sql;
using MajornaGameStore.DataAccess.Sql.Repositories;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Hosting.Server;
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
    .AddScoped<IEventTypeRepository, EventTypeRepository>()
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
.AddScoped<OrderService>();

builder.Services.AddOptions<StripeConfig>().BindConfiguration(nameof(StripeConfig));

builder.Services.AddScoped<MajornaGameStore.Api.Stripe.StripeClient>();

//StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];


////add cors for no errors later on
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//    });
//});

builder.Services.AddRouting(options => options.LowercaseUrls = true);
//builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//enligt instruktioner so that asp.net can activate these services
//app.UseCors();
//app.UseRouting();


app.UseHttpsRedirection();

//app.MapLoadProductEndPoints();
app.MapProductEndPoints();
app.MapEventEndPoints();
app.MapEventTypeEndPoints();
app.MapOrderEndPoints();
app.MapPaymentsEndPoints();
//app.MapControllers();

app.Run();

using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;
using MongoDB.Bson;

namespace MajornaGameStore.Api.Extensions;

public static class OrderExtensions
{
    public static IEndpointRouteBuilder MapOrderEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orders");

        group.MapGet("/", GetAllOrdersAsync);
        group.MapGet("/{id}", GetOrderByIdAsync);
        group.MapPost("/", AddOrderAsync);
        group.MapDelete("/{id}", DeleteOrderAsync);
        return app;
    }

    public static async Task<IResult> GetAllOrdersAsync(OrderService orderService)
    {
        var orders = await orderService.GetAllAsync();

        return Results.Ok(orders);
    }

    public static async Task<IResult> GetOrderByIdAsync(OrderService orderService, string id)
    {
        var parsedId = ObjectId.Parse(id);
        var order = await orderService.GetByIdAsync(parsedId);

        if (order is null)
            return Results.NotFound($"Order with id {id} does not exist.");

        return Results.Ok(order);
    }

    public static async Task<IResult> AddOrderAsync(OrderService orderService, Order newOrder)
    {
        var newlyAddedOrder = await orderService.AddAsync(newOrder);

        return Results.Ok(newlyAddedOrder);
    }


    public static async Task<IResult> DeleteOrderAsync(OrderService orderService, string id)
    {
        var parsedId = ObjectId.Parse(id);
        var orderExists = await orderService.DeleteAsync(parsedId);

        if (orderExists == false)
        {
            return Results.NotFound($"No product with id {id} exists.");
        }

        return Results.Ok();
    }
}
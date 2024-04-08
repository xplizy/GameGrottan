using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.DataAccess.Sql.Repositories;
using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.Api.Extensions;

public static class ProductExtensions
{
    public static IEndpointRouteBuilder MapProductEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");

        group.MapGet("/", GetAllProductsAsync);
        group.MapGet("/{id}", GetProductByIdAsync);
        return app;
    }

    public static async Task<IResult> GetAllProductsAsync(ProductService productService)
    {
        var products = await productService.GetAllAsync();
        return Results.Ok(products);
    }

    public static async Task<IResult> GetProductByIdAsync(ProductService productService, int id)
    {
        var product = await productService.GetByIdAsync(id);

        if (product is null)
            return Results.NotFound();

        return Results.Ok(product);
    }
}
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.DataAccess.Sql.Repositories;
using MajornaGameStore.Shared.Interfaces;
using System;

namespace MajornaGameStore.Api.Extensions;

public static class ProductExtensions
{
    public static IEndpointRouteBuilder MapProductEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");

        group.MapGet("/", GetAllProductsAsync);
        group.MapGet("/{id}", GetProductByIdAsync);
        group.MapGet("/type/{typeId}", GetProductsByTypeIdAsync);
        group.MapGet("/tag/{tagId}", GetProductsByTagIdAsync);
        group.MapGet("/discounts", GetAllProductsWithDiscountsAsync);
        group.MapGet("/discounts/{discountId}", GetProductsByDiscountId);
        return app;
    }
    public static async Task<IResult> GetProductsByDiscountId(ProductService productService, DiscountService discountService, int discountId)
    {
        var doesDiscountIdExist = discountService.GetByIdAsync(discountId);
        if (doesDiscountIdExist is null)
            return Results.NotFound($"Discount with id {discountId} does not exist");

        var products = await productService.GetProductsByDiscountId(discountId);
        return Results.Ok(products);
    }
    public static async Task<IResult> GetAllProductsWithDiscountsAsync(ProductService productService)
    {
        var products = await productService.GetAllProductsWithDiscounts();
        return Results.Ok(products);
    }
    public static async Task<IResult> GetProductsByTagIdAsync(ProductService productService, TagService tagService, int tagId)
    {
        var doesTagIdExist = tagService.GetByIdAsync(tagId);
        if (doesTagIdExist is null)
            return Results.NotFound($"Product tag with id {tagId} does not exist");

        var products = await productService.GetAllProductsByTag(tagId);
        return Results.Ok(products);
    }
    public static async Task<IResult> GetProductsByTypeIdAsync(ProductService productService, ProductTypeService productTypeService ,int typeId)
    {
        var doesTypeIdExist = productTypeService.GetByIdAsync(typeId);
        if (doesTypeIdExist is null)
            return Results.NotFound($"Product type with id {typeId} does not exist");

        var products = await productService.GetAllProductsByTypeAsync(typeId);
        return Results.Ok(products);
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
            return Results.NotFound($"Product with id {id} does not exist.");

        return Results.Ok(product);
    }
}
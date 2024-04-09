using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.DataAccess.Sql.Repositories;
using MajornaGameStore.Shared.Interfaces;
using System;
using MajornaGameStore.DataAccess.Entities;

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
        group.MapPost("/", AddProductAsync);
        group.MapPut("/", UpdateProductAsync);
        group.MapDelete("/{id}", DeleteProductAsync);
        return app;
    }

    public static async Task<IResult> DeleteProductAsync(ProductService productService, int id)
    {
        var entityExists = await productService.DeleteAsync(id);

        if (entityExists == false)
        {
            return Results.NotFound($"No product with id {id} exists.");
        }

        return Results.Ok();
    }

    public static async Task<IResult> UpdateProductAsync(ProductService productService, Product product)
    {
        var entityExists = await productService.UpdateAsync(product);

        if (entityExists == false)
        {
            return Results.NotFound($"No product with id {product.Id} exists.");
        }

        return Results.Ok();
    }

    public static async Task<IResult> AddProductAsync(ProductService productService, Product newProduct)
    {
        var newlyAddedProduct = await productService.AddAsync(newProduct);

        return Results.Ok(newlyAddedProduct);
    }

    public static async Task<IResult> GetProductsByDiscountId(ProductService productService, int discountId)
    {
        var products = await productService.GetProductsByDiscountId(discountId);
        if (products is null)
            return Results.NotFound($"Discount with id {discountId} does not exist");

        return Results.Ok(products);
    }
    public static async Task<IResult> GetAllProductsWithDiscountsAsync(ProductService productService)
    {
        var products = await productService.GetAllProductsWithDiscounts();
        return Results.Ok(products);
    }
    public static async Task<IResult> GetProductsByTagIdAsync(ProductService productService, int tagId)
    {
        var products = await productService.GetAllProductsByTagId(tagId);
        if (products is null)
            return Results.NotFound($"Product tag with id {tagId} does not exist");

        return Results.Ok(products);
    }
    public static async Task<IResult> GetProductsByTypeIdAsync(ProductService productService, int typeId)
    {
        var products = await productService.GetAllProductsByTypeIdAsync(typeId);
        if (products is null)
            return Results.NotFound($"Product type with id {typeId} does not exist");

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
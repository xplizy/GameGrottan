using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.Shared.Dtos;

namespace MajornaGameStore.Api.Extensions;

public class UserExtenstions
{
    public static IEndpointRouteBuilder MapProductEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/manage");

        group.MapGet("/{email}", GetRoleInfoByEmail);
        return app;
    }


    public static async Task<IResult> GetRoleInfoByEmail(UserService userService, string email)
    {
        var products = await userService.GetRolesByEmail(email);

        if (products is null)
            return Results.NotFound($"User with email {email} does not exist");

        var productDtos = new List<ProductDto>();
        foreach (var product in products)
        {
            var dto = await product.MapToDtoAsync();
        }

        return Results.Ok(productDtos);
    }
}
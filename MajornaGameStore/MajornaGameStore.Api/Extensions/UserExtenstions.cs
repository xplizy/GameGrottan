using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.Shared.Dtos;

namespace MajornaGameStore.Api.Extensions;

public static class UserExtenstions
{
    public static IEndpointRouteBuilder MapUserEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/manage");

        group.MapGet("/{email}", GetRoleInfoByEmail);
        return app;
    }


    public static async Task<IResult> GetRoleInfoByEmail(UserService userService, string email)
    {
        var roles = await userService.GetRolesByEmail(email);

        if (roles is null)
            return Results.NotFound($"User with email {email} does not exist");


        return Results.Ok(roles);
    }
}
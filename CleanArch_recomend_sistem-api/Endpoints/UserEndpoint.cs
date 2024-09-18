
using Microsoft.AspNetCore.Mvc;
using CleanArch_recomend_sistem.application.Users;
using CleanArch_recomend_sistem.Core.DTOs;

namespace CleanArch_recomend_sistem_api.Endpoints;

public static class UserEndpoint
{

    public static void MapProjectEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/users", GetUsers);
        routes.MapPost("/users/", AddUser);
    }

    private static async Task<IResult> GetUser(UserService service, CancellationToken cancellationToken)
    {
        try
        {
            return Results.Ok(await service.GetUserServiceAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> AddOrUpdateUser([FromBody]UserDTO userDTO, UserService service, CancellationToken cancellationToken)
    {
        try
        {
            await service.RegisterOrUpdateUsersAsync(cancellationToken);
            return Results.Ok();
            
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
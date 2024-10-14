using Microsoft.AspNetCore.Mvc;
using CleanArch_recomend_sistem.application.Recommendation;
using CleanArch_recomend_sistem.Core;
using System.Threading.Tasks;
using System;

namespace CleanArch_recomend_sistem_api.Endpoints;

public static class RecommendationEndpoint
{
    public static void MapRecommendationEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/recommendations/{userId:guid}", GetRecommendations);
    }

    private static async Task<IResult> GetRecommendations(Guid userId, RecommendationService recommendationService, CancellationToken cancellationToken)
    {
        try
        {
            var id = new Id(userId);

            var recommendations = await recommendationService.GetRecommendedMoviesAsync(id, cancellationToken);

            if (recommendations == null || !recommendations.Any())
            {
                return Results.NotFound($"No recommendations found for user with ID {userId}.");
            }

            return Results.Ok(recommendations);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}


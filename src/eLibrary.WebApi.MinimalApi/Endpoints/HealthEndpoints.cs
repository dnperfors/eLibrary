using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using static System.Net.Mime.MediaTypeNames;

namespace eLibrary.WebApi.MinimalApi.Endpoints;

internal static class HealthEndpoints
{
    internal static void MapHealthEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/health", GetHealth)
            .WithName("Health")
            .WithDescription("Health check for external monitoring purposes")
            .Produces<string>(StatusCodes.Status200OK, Text.Plain)
            .Produces<string>(StatusCodes.Status503ServiceUnavailable, Text.Plain)
            .WithOpenApi();
        routes.MapHealthChecks("/health/alive", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions { Predicate = _ => false });
        routes.MapHealthChecks("/health/ready", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions { Predicate = x => x.Tags.Contains("ready") });
    }

    internal static async Task<IResult> GetHealth(HealthCheckService healthCheckService)
    {
        var healthReport = await healthCheckService.CheckHealthAsync();
        var statusCode = healthReport.Status switch
        {
            HealthStatus.Healthy => StatusCodes.Status200OK,
            HealthStatus.Unhealthy or
            HealthStatus.Degraded => StatusCodes.Status503ServiceUnavailable
        };

        return Results.Content(healthReport.Status.ToString(), Text.Plain, statusCode: statusCode);
    }
}

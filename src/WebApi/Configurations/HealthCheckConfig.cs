using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApi.Configurations;

public static class HealthCheckConfig
{
    public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
                .AddNpgSql(
                    connectionString: configuration.GetConnectionString("DefaultConnection"),
                    name: "postgresql",
                    failureStatus: HealthStatus.Unhealthy,
                    tags: new[] { "database", "postgresql" })
                .AddCheck("self", () => HealthCheckResult.Healthy("API is running"))
                .AddCheck("memory", () =>
                {
                    var allocated = GC.GetTotalMemory(false);
                    var data = new Dictionary<string, object>
                    {
                        { "allocated", allocated },
                        { "allocated_mb", allocated / 1024 / 1024 }
                    };

                    return allocated > 1024 * 1024 * 100 // 100MB
                        ? HealthCheckResult.Unhealthy("High memory usage", data: data)
                        : HealthCheckResult.Healthy("Memory usage is normal", data: data);
                });

        return services;
    }

    public static IApplicationBuilder UseHealthChecks(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
        {
            ResponseWriter = async (context, report) =>
            {
                context.Response.ContentType = "application/json";
                var result = new
                {
                    status = report.Status.ToString(),
                    checks = report.Entries.Select(entry => new
                    {
                        name = entry.Key,
                        status = entry.Value.Status.ToString(),
                        description = entry.Value.Description,
                        duration = entry.Value.Duration.ToString(),
                        data = entry.Value.Data
                    }),
                    totalDuration = report.TotalDuration.ToString()
                };

                await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(result));
            }
        });

        // Health check simples para load balancer
        app.UseHealthChecks("/health/ready", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("database")
        });

        return app;
    }
}
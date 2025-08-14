using Microsoft.AspNetCore.Mvc;

namespace WebApi.Configurations;

public static class JsonConfig
{
    public static IServiceCollection AddJsonConfiguration(this IServiceCollection services)
    {
        services.Configure<JsonOptions>(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        });

        return services;
    }
}

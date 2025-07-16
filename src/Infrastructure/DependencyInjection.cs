using Application.Common.Interfaces;
using Application.Common.Repositories;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationExternalDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure the DbContext
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgresConnection")));



            // Register the repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            // Register the Services
            services.AddScoped<IApplicationUserService, ApplicationUserService>();

            // Register migration service
            // services.AddTransient<IMigration, SeedUsersMigration>();

            // TODO: Configure migrations

            return services;
        }
    }
}

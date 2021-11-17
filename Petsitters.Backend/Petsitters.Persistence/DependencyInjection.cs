using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Petsitters.Application.Interfaces;

namespace Petsitters.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IAppDbContext>(provider =>
                provider.GetService<AppDbContext>());
            return services;
        }
    }
}

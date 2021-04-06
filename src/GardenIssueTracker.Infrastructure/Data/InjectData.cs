using GardenIssueTracker.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GardenIssueTracker.Infrastructure.Data
{
    public static class InjectData
    {
        public static IServiceCollection InjectDataLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<GardenDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(GardenDbContext).Assembly.FullName)));

            services.AddScoped<IGardenDbContext>(provider => provider.GetService<GardenDbContext>());

            return services;
        }
    }
}

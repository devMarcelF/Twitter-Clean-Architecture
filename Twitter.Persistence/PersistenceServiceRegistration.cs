using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Twitter.Application.Contracts.Persistence;
using Twitter.Persistence.Repositories;

namespace Twitter.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TwitterDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TwitterStatisticConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ITwitterStatisticRepository, TwitterStatisticRepository>();

            return services;
        }
    }
}

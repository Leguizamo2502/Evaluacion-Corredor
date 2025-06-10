using Entity.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Web.Services
{
    public static class DatabaseService
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            return services;
        }
    }
}

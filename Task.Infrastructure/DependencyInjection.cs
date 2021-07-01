using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Application.Common.Interfaces;
using Test.Infrastructure.Persistence;
using Test.Infrastructure.Services;

namespace Test.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("getworkMemoryDatabse"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddSingleton<ICookieService, CookieService>();
            
            return services;
        }
    }
}

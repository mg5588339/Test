using AutoMapper;
using FluentValidation;
using Getwork.Application.Users.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Test.Application.Users.Implementations;
using Test.Application.Users.Interfaces;
using Test.Application.Weather.Implementations;
using Test.Application.Weather.Interfaces;

namespace Test.Application
{
    public static class DependencyInjection
    {
        public static IConfiguration Configuration { get; set; }
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration = configuration;

            // Application Configuration
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMemoryCache();

            // Application Dependency
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IWeatherService, WeatherService>();

            return services;
        }
    }
}

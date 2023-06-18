using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenrator, JwtTokenGenrator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
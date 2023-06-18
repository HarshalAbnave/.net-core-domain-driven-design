using BuberDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application
{
    public static class ApplicationDependenctInjection
    {
        public static IServiceCollection AddApplicationDependency(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
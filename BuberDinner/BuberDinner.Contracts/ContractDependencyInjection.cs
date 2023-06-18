using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Contracts
{
    public static class ContractDependencyInjection
    {
        public static IServiceCollection AddContractDependency(this IServiceCollection service)
        {
            return service;
        }
    }
}
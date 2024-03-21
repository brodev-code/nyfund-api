using NyFund.Core.Repository.Implement;
using NyFund.Core.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace NyFund.Core.Repository.IoC
{
    public static class RepositoryContainer
    {
        public static void AddScopedRepository(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}

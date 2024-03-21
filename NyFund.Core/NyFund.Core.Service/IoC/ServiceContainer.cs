using NyFund.Core.Service.Implement;
using NyFund.Core.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace NyFund.Core.Service.IoC
{
    public static class ServiceContainer
    {
        public static void AddScopedService(this IServiceCollection services)
        {
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}

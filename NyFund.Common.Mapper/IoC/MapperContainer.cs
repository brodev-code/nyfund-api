using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NyFund.Common.Mapper.Profiles;

namespace NyFund.Common.Mapper.IoC
{
    public static class MapperContainer
    {
        public static void AddScopedMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomerProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

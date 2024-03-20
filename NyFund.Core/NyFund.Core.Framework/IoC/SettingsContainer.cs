using NyFund.Core.Framework.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NyFund.Core.Framework.IoC
{
    public static class SettingsContainer
    {
        public static IServiceCollection AddSettingsContainer(this IServiceCollection app, IConfiguration configuration)
        {
            AppSettingsHelper.AppSettingsHelperConfigure(configuration);
            return app;
        }
    }
}

using NyFund.Core.Framework.DataAccessLayer.EntityCore.UnitOfWork;
using NyFund.Core.Framework.Enums;
using NyFund.Core.Framework.Settings;
using NyFund.Data.DataAccessLayer.Database;
using NyFund.Data.DataAccessLayer.EntityCore.UnitOfWork;
using NyFund.Data.DataAccessLayer.Redis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NyFund.Data.DataAccessLayer.IoC
{
    public static class DataAccessLayerContainer
    {
        public static void AddDatabaseContext<TContext>(this IServiceCollection services, string connectionKey, IConfiguration configuration) where TContext : DbContextBase
        {
            services.AddDbContext<TContext>(optionsBuilder =>
            {
                var dbConfiguration = configuration.GetSection($"DatabaseSettings:{connectionKey}").Get<DatabaseSettings>();
                switch (dbConfiguration.DatabaseType)
                {
                    case DatabaseType.SqlServer:
                        optionsBuilder.UseSqlServer(dbConfiguration.ConnectionString);
                        break;
                    case DatabaseType.SqlLite:
                        optionsBuilder.UseSqlite(dbConfiguration.ConnectionString);
                        break;
                    case DatabaseType.Postgre:
                        optionsBuilder.UseNpgsql(dbConfiguration.ConnectionString);
                        break;
                    default:
                        throw new NotSupportedException($"Name {dbConfiguration.DatabaseType}:is not supported");
                }
            }).AddScoped<DbContextBase, TContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddRedis(this IServiceCollection services)
        {
            var server = AppSettingsHelper.RedisSettings.Server;
            RedisConnection.SetConnectionString(server);
        }
    }
}

using NyFund.Core.Framework.Settings;
using StackExchange.Redis;

namespace NyFund.Data.DataAccessLayer.Redis
{
    public static class RedisConnection
    {
        private static string _connectionString;
        private static Lazy<ConfigurationOptions> _configurationOptions;
        private static Lazy<ConnectionMultiplexer> _connection;

        public static void SetConnectionString(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Redis connection string is empty or null");

            _connectionString = connectionString;

            var options = new ConfigurationOptions
            {
                ClientName = AppSettingsHelper.RedisSettings.ClientName,
                ConnectTimeout = AppSettingsHelper.RedisSettings.ConnectTimeout,
                SyncTimeout = AppSettingsHelper.RedisSettings.SyncTimeout,
                AbortOnConnectFail = AppSettingsHelper.RedisSettings.AbortOnConnectFail,

            };

            if (!string.IsNullOrEmpty(AppSettingsHelper.RedisSettings.Password))
                options.Password = AppSettingsHelper.RedisSettings.Password;
 
            options.EndPoints.Add(_connectionString);

            _configurationOptions = new Lazy<ConfigurationOptions>(options);
            _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_configurationOptions.Value));
        }

        public static ITransaction CreateTransaction()
        {
            return _connection.Value.GetDatabase().CreateTransaction();
        }

        public static IDatabase GetConnection()
        {
            return _connection.Value.GetDatabase();
        }
    }
}

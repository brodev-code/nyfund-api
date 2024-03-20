
namespace NyFund.Core.Framework.Settings
{
    public class RedisSettings
    {
        public string Server { get; set; }
        public string ClientName { get; set; }
        public int ConnectTimeout { get; set; }
        public int SyncTimeout { get; set; }
        public bool AbortOnConnectFail { get; set; }
        public string Password { get; set; }
    }
}

using NyFund.Core.Framework.Enums;

namespace NyFund.Core.Framework.Settings
{
    public class DatabaseSettings
    {
        public DatabaseType DatabaseType { get; set; }
        public string ConnectionString { get; set; }
    }
}

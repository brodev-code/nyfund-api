using Microsoft.Extensions.Configuration;

namespace NyFund.Core.Framework.Settings
{
    public static class AppSettingsHelper
    {
        private static IConfiguration configuration;

        public static void AppSettingsHelperConfigure(IConfiguration _configuration)
        {
            configuration = _configuration;

            RedisSettings = configuration.GetSection("RedisSettings").Get<RedisSettings>();
            OtpSettings = configuration.GetSection("RedisSettings").Get<OtpSettings>();
            SmtpSettings = configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
            TokenSettings = configuration.GetSection("TokenSettings").Get<TokenSettings>();
            EncryptionSettings = configuration.GetSection("EncryptionSettings").Get<EncryptionSettings>();
            NviSettings = configuration.GetSection("NviSettings").Get<NviSettings>();
            CentralBankCurrencySettings = configuration.GetSection("CentralBankCurrencySettings").Get<CentralBankCurrencySettings>();
            HangfireSettings = configuration.GetSection("HangfireSettings").Get<HangfireSettings>();
            FileUploadSettings = configuration.GetSection("FileUploadSettings").Get<FileUploadSettings>();
        }

        public static RedisSettings RedisSettings { get; set; }
        public static OtpSettings OtpSettings { get; set; }
        public static SmtpSettings SmtpSettings { get; set; }
        public static TokenSettings TokenSettings { get; set; }
        public static EncryptionSettings EncryptionSettings { get; set; }
        public static NviSettings NviSettings {get; set;}
        public static CentralBankCurrencySettings CentralBankCurrencySettings { get; set;}
        public static HangfireSettings HangfireSettings { get; set;}
        public static FileUploadSettings FileUploadSettings { get; set;}
    }
}

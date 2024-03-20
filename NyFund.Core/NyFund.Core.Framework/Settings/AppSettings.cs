
namespace NyFund.Core.Framework.Settings
{
    public class AppSettings
    {
        public RedisSettings RedisSettings { get; set; }
        public OtpSettings OtpSettings { get; set; }
        public SmtpSettings SmtpSettings { get; set; }
        public EncryptionSettings EncryptionSettings { get; set; }
        public NviSettings NviSettings { get; set; }
        public CentralBankCurrencySettings CentralBankCurrencySettings { get; set; }
        public HangfireSettings HangfireSettings { get; set; }
        public FileUploadSettings FileUploadSettings { get; set; }
    }
}

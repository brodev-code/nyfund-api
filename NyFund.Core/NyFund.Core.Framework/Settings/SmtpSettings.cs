
namespace NyFund.Core.Framework.Settings
{
    public class SmtpSettings
    {
        public bool IsActive { get; set; }
        public string Host { get; set; }
        public int TLSPort { get; set; }
        public int SSLPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
    }
}

using System.ComponentModel;

namespace NyFund.Core.Framework.Enums
{
    public enum NotificationType
    {
        [Description("Sözleşme Bildirimi")]
        Contract = 0,

        [Description("Başarısız Giriş Bildirimi")]
        FailedLogin = 1,

        [Description("Sistem Bildirimi")]
        System = 2,
	}
}

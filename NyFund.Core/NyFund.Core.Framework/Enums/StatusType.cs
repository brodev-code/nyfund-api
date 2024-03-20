using System.ComponentModel;

namespace NyFund.Core.Framework.Enums
{
    public enum StatusType
    {
        [Description("Bekliyor")]
        Pending = 0,

        [Description("İşleniyor")]
        Processing = 1,

        [Description("Tamamlandı")]
        Completed = 2,

        [Description("Hata")]
        Error = 3
    }
}

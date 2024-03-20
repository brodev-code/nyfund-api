using System.ComponentModel;

namespace NyFund.Core.Framework.Enums
{
    public enum ChangeStatusType
    {
        [Description("Bekliyor")]
        Wait = 0,

        [Description("Başarılı")]
        Done = 1,

        [Description("Hata")]
        Error = 2
    }
}

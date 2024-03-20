using System.ComponentModel;

namespace NyFund.Core.Framework.Enums
{
    public enum ProcessType
    {
        [Description("Müşteri")]
        Customer = 0,

        [Description("Kullanıcı")]
        Employee = 1
    }
}

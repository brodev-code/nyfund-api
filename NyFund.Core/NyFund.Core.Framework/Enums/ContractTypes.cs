using System.ComponentModel;

namespace NyFund.Core.Framework.Enums
{
    public enum ContractTypes : long
    {
        [Description("Müşteri Sözleşme Tipi")]
        Customer = 1,

        [Description("Çalışan Sözleşme Tipi")]
        Employee = 2
    }
}

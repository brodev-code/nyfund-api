using System.ComponentModel;

namespace NyFund.Core.Framework.Enums
{
    public enum NotificationPriorityType
    {
        [Description("Standart")]
        Low = 0,

		[Description("Normal")]
		Normal = 1,

		[Description("Önemli")]
        Medium = 2,

        [Description("Yüksek")]
        High = 3
    }
}

using System.ComponentModel.DataAnnotations;

namespace NyFund.Core.Framework.Enums
{
    public enum SenderType
    {
        [Display(Name = "Sms")]
        Sms = 0,

        [Display(Name = "Email")]
        Email = 1,
    }
}

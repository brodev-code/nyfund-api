using System.ComponentModel.DataAnnotations;

namespace NyFund.Core.Framework.Enums
{
    public enum  Gender : int
    {
        [Display(Name = "Kadın")]
        Female = 0,

        [Display(Name = "Erkek")]
        Male = 1,

        [Display(Name = "Diğer")]
        Other = 2,

        [Display(Name = "Tanımsız")]
        Undefined = 3
    }
}

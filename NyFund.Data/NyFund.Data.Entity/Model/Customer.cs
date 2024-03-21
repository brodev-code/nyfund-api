using NyFund.Core.Framework.Base;
using NyFund.Core.Framework.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NyFund.Data.Entity.Model
{
    [Table("Customer", Schema = "dbo")]
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public long JobId { get; set; }
        public bool IsIdentityValidate { get; set; }
        public bool? IsOtpActive { get; set; }
        public DateTime? OtpActiveDate { get; set; }
        public int WarningCount { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public YesNoType IsBanned { get; set; }
        public string BanReason { get; set; }
        public DateTime? BanEndDate { get; set; }
    }
}


namespace NyFund.Core.Framework.Base
{
    public abstract class BaseEntity : IEntity
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public long? CreateById { get; set; }
        public long? UpdateById { get; set; }
        public long? DeleteById { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}

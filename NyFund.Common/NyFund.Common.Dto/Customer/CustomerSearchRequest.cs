using NyFund.Core.Framework.Paging;

namespace NyFund.Common.Dto.Customer
{
    public class CustomerSearchRequest : PagingRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

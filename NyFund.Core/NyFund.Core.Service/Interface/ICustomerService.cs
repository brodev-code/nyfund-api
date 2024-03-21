using NyFund.Common.Dto.Customer;
using NyFund.Core.Framework.Base;
using NyFund.Core.Framework.Paging;

namespace NyFund.Core.Service.Interface
{
    public interface ICustomerService
    {
        Task<Result<PagingResult<CustomerResponse>>> Search(CustomerSearchRequest request);
    }
}

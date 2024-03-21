using Microsoft.AspNetCore.Mvc;
using NyFund.Common.Dto.Customer;
using NyFund.Core.Framework.Base;
using NyFund.Core.Framework.Paging;
using NyFund.Core.Service.Interface;

namespace NyFund.Api.Panel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Search")]
        public async Task<Result<PagingResult<CustomerResponse>>> Search([FromBody] CustomerSearchRequest request)
        {
            var result = await _customerService.Search(request);
            return result;
        }
    }
}

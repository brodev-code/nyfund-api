using AutoMapper;
using NyFund.Core.Framework.Base;
using NyFund.Core.Framework.DataAccessLayer.EntityCore.UnitOfWork;
using NyFund.Core.Framework.Enums;
using NyFund.Core.Framework.Paging;
using NyFund.Core.Framework.Settings;
using NyFund.Core.Repository.Interface;
using NyFund.Core.Service.Base;
using NyFund.Core.Service.Helper;
using NyFund.Core.Service.Interface;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace NyFund.Core.Service.Implement
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

		public CustomerService(IUnitOfWork unitOfWork,
			IHttpContextAccessor httpContextAccessor,
			//ITokenService tokenService,
			IMapper mapper,
			ICustomerRepository customerRepository,
			IOptions<AppSettings> appSettings) : base(unitOfWork, httpContextAccessor, /*tokenService,*/ mapper)
		{
			_customerRepository = customerRepository;
		}
	}
}

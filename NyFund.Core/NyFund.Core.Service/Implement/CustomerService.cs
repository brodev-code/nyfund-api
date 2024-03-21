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
using NyFund.Common.Dto.Customer;
using System.Diagnostics.Contracts;
using NyFund.Data.Entity.Model;

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

        public async Task<Result<PagingResult<CustomerResponse>>> Search(CustomerSearchRequest request)
        {
            var response = new Result<PagingResult<CustomerResponse>>();

            try
            {
                #region PredicateBuilder

                var predicateBuilder = PredicateBuilder.New<Customer>(x => !x.IsDelete && x.IsActive);

                if (!string.IsNullOrEmpty(request.Name))
                {
                    predicateBuilder = predicateBuilder.And(x => x.Name.ToLower().Contains(request.Name));
                }

                if (!string.IsNullOrEmpty(request.Surname))
                {
                    predicateBuilder = predicateBuilder.And(x => x.Surname.ToLower().Contains(request.Surname));
                }

                #endregion

                var data = _customerRepository.GetQuery(predicateBuilder)
                                .Select(x => new CustomerResponse()
                                {
                                    Name = x.Name,
                                    Surname = x.Surname
                                });

                if (data == null || !data.Any())
                {
                    return Result<PagingResult<CustomerResponse>>.CreateErrorResult(ErrorCode.NotFound, "Kayıt Bulunamadı");
                }

                response.IsSuccess = true;
                response.Data = await data.ToPagedListAsync(request);
            }
            catch (Exception ex)
            {
                return Result<PagingResult<CustomerResponse>>.CreateErrorResult(ErrorCode.Unknown, ex.InnerException?.Message ?? ex.Message);
            }

            return response;
        }
    }
}

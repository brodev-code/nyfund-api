using AutoMapper;
using NyFund.Common.Dto.Customer;
using NyFund.Data.Entity.Model;

namespace NyFund.Common.Mapper.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResponse>().ReverseMap();
        }
    }
}

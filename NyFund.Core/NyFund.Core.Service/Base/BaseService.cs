using AutoMapper;
using Microsoft.AspNetCore.Http;
using NyFund.Core.Framework.DataAccessLayer.EntityCore.UnitOfWork;
using NyFund.Core.Service.Interface;

namespace NyFund.Core.Service.Base
{
    public class BaseService { 

        public readonly IUnitOfWork _unitOfWork;
        public readonly IHttpContextAccessor _httpContextAccessor;
        //public readonly ITokenService _tokenService;
        public readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, 
            IHttpContextAccessor httpContextAccessor,
            //ITokenService tokenService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            //_tokenService = tokenService;
            _mapper = mapper;
        }
    }
}


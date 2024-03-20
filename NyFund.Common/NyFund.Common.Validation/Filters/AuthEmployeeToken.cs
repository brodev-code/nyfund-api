/*using NyFund.Common.Dto.Session;
using NyFund.Core.Service.Helper;
using NyFund.Core.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NyFund.Common.Validation.Filters
{
    public class AuthEmployeeToken : ActionFilterAttribute
    {
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthEmployeeToken(ITokenService tokenService,
            IHttpContextAccessor httpContextAccessor)
        {
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            NotAllowAnonymous controllerNotAllowAnonymous = null;
            AllowAnonymousAttribute actionAllowAnonymous = null;

            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                controllerNotAllowAnonymous = controllerActionDescriptor.EndpointMetadata.OfType<NotAllowAnonymous>().FirstOrDefault();
            }

            if (context.ActionDescriptor is ActionDescriptor actionDescriptor)
            {
                actionAllowAnonymous = actionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().FirstOrDefault();
            }

            if (controllerNotAllowAnonymous != null && actionAllowAnonymous != null)
            {
                return;
            }

            string accessToken = null;
            bool hasAuthorizationHeader = context.HttpContext.Request.Headers.ContainsKey("Authorization");

            if (hasAuthorizationHeader)
            {
                accessToken = context.HttpContext.Request.Headers["Authorization"];
            }

            if (!string.IsNullOrEmpty(accessToken) && accessToken.StartsWith("Bearer "))
                accessToken = accessToken.Replace("Bearer ", "").Trim();

            if (string.IsNullOrEmpty(accessToken) || accessToken == "null")
            {
                context.Result = new BadRequestObjectResult("Authorization Header Is Empty"); //400
                return;
            }

            var id = TokenHelper.GetTokenId(accessToken);
            if (id == -1)
            {
                context.Result = new UnauthorizedObjectResult("Invalid Token"); //401
                return;
            }

            var authDto = _tokenService.GetAuthEmployee(id);

            if (authDto.Result == null)
            {
                context.Result = new UnauthorizedObjectResult("Expired Access Token"); //401
                return;
            }

            if (authDto.Result.AccessToken == null)
            {
                context.Result = new UnauthorizedObjectResult("Expired Access Token"); //401
                return;
            }

            if (string.IsNullOrEmpty(authDto.Result.AccessToken.Token))
            {
                context.Result = new UnauthorizedObjectResult("Expired Access Token"); //401
                return;
            }

			EmployeeSession.SetSession(authDto.Result);
			EmployeeSession.Id = authDto.Result.Id;
			context.HttpContext.Items.Add("EmployeeSession", authDto.Result);
		}
    }
}
*/
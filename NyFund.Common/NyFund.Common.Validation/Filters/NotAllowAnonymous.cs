using Microsoft.AspNetCore.Mvc.Filters;

namespace NyFund.Common.Validation.Filters
{
    public class NotAllowAnonymous : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
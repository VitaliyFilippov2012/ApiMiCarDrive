using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using MiWebApi.Helpers;

namespace MiWebApi.Aspects
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await base.OnActionExecutionAsync(context, next);
            if (!TokenServiceHelper.ValidateToken(RequestHelper.GetTokenFromRequest(context.HttpContext.Request)))
                context.HttpContext.Response.StatusCode = 401;
        }
    }
}

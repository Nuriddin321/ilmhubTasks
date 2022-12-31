using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace attributeTutorial.Attributes;

public class OnlyAdminAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // return base.OnActionExecutionAsync(context, next);
        
        var userClaims = context.HttpContext.User;
        var userRole = userClaims.FindFirst(uc => uc.Type == ClaimTypes.Role)?.Value;

        if(userRole != "admin")
        {
            context.Result = new BadRequestResult();
            return;
        }
        
        await next();
    }
}
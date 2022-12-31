using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace attributeTutorial.Attributes;

// public class IsAdminAttribute : TypeFilterAttribute
// {
//     public IsAdminAttribute(bool onlyAdmin = false) : base(typeof(OnlyAdminAttribute))
//     {
//         Arguments = new object[] { onlyAdmin };
//     }
// }

public class IsAdminAttribute : ActionFilterAttribute
{
    public bool OnlyAdmin { get; set; }

    public IsAdminAttribute(bool onlyAdmin)
    {
        OnlyAdmin = onlyAdmin;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var userClaims = context.HttpContext.User;

        var userRole = userClaims.FindFirst(uc => uc.Type == ClaimTypes.Role)?.Value;

        if(OnlyAdmin)
        {
            if(userRole != "admin")
            {
                context.Result = new BadRequestResult();
                return;
            }
        }

        await next();
    }

}

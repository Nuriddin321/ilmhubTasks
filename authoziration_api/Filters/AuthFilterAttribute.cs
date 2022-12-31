using Microsoft.AspNetCore.Mvc.Filters;

namespace authoziration_api.Filters;

public class AuthFilterAttribute : ActionFilterAttribute
{
    private readonly UserStore _store;

    public AuthFilterAttribute(UserStore store)
    {
        _store = store;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.ContainsKey("Key"))
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.HttpContext.Response.WriteAsync("royxatdan o'tmagan");
            return;
        }

        var key = context.HttpContext.Request.Headers["Key"];  
        if(!_store.Users.ContainsKey(key))
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.HttpContext.Response.WriteAsync("royxatdan o'tmagan");
        }
    }
}
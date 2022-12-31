using Microsoft.AspNetCore.Mvc.Filters;

namespace middleware.Filters;

public class TilFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        RequestCulture.RequestTili =
            context.HttpContext.Request.Headers.First(h => h.Key == "Til").Value;

        if (RequestCulture.RequestTili != "uz" && RequestCulture.RequestTili != "en")
        {
            throw new LanguageNotSupportedException();
        }
    }
}

public class LanguageNotSupportedException : Exception
{
    public LanguageNotSupportedException() : base ("Only 'uz', 'en'") { }
}
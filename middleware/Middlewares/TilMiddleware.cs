namespace middleware.Middlewares;

public class TilMiddleware
{
    private readonly RequestDelegate _next;

    public TilMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        if (!httpContext.Request.Headers.ContainsKey("Til"))
        {
            throw new Exception("Language header missed!");
        }

        RequestCulture.RequestTili = httpContext.Request.Headers["Til"];
        return _next(httpContext);
    }   

}

public class HttpContextHelper
{
    public static IHttpContextAccessor Accessor;
    public static HttpContext Current => Accessor?.HttpContext;

    public static void AddResponseHeader(string key, string value)
    {
        if (Current?.Response.Headers.Keys.Contains(key) == true)
            Current.Response.Headers.Remove(key);

        Current?.Response.Headers.Add("pagination-key", key); // Access-Control-Expose-Headers
        Current?.Response.Headers.Add(key, value);
    }
}
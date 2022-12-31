using authentication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace authentication.Filters;

public class RoleAttribute : TypeFilterAttribute
{
    public RoleAttribute(string role) : base(typeof(AuthAttribute))
    {
        Arguments = new object[] { role };
    }
}
using authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;

namespace authentication.Filters;

public class AuthAttribute : ActionFilterAttribute
{
    private readonly PathConfig _config;
    public string Roles {get; set;}

    public AuthAttribute(IOptions<PathConfig> options, string role)
    {
        _config = options.Value;
        Roles = role;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.ContainsKey("Token"))
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        //requestni headeridan tokenni ajratib olish
        var token = context.HttpContext.Request.Headers["Token"];

        ////shu token orqali userni  databazadan qidirish
        var readData = System.IO.File.ReadAllText(_config.SaveFolder);

        var users = JsonConvert.DeserializeObject<List<User>>(readData);

        var user = users?.FirstOrDefault(u => u.Token == token);

        if (users is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!Roles.Contains(user!.Role!))
        {
            context.Result = new JsonResult(new {Error = "bu yerga faqat adminlar kira oladi"});
            return;
        }

        //token boyicha topilgan userni claimlaga qo'wib chiqish
        var claims = new List<Claim>()
        {
            new Claim("Id", user?.Id!),
            new Claim(ClaimTypes.Name, user?.Name!),
            new Claim(ClaimTypes.Role, user?.Role!),
            new Claim("Token", user?.Token!),
        };

        var identity = new ClaimsIdentity(claims);

        var principal = new ClaimsPrincipal(identity);

        context.HttpContext.User = principal;
    }
}
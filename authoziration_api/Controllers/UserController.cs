using System.Net;
namespace authoziration_api.Controllers;

using System.Security.Claims;
using authoziration_api.Data;
using authoziration_api.Filters;
using authoziration_api.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult UserRegister(string name, string password)
    {
        var key = Guid.NewGuid().ToString();

        var user = new User()
        {
            Username = name,
            Password = password,
            Key = key
        };

        _context.Users.Add(user);

        return Ok(key);
    }

    [HttpPost("counter")]
    public IActionResult Counter(string key, int N, int K)
    {
        var user = _context.Users.FirstOrDefault(u => u.Key == key);
        if (user is null)
            return Unauthorized();

        var count = 0;
        for (int i = 1; i <= N; i++)
        {
            var num = i;
            while (num > 0)
            {
                var digit = num % 10;
                if (digit == K)
                {
                    count++;
                }
                num /= 10;
            }
        }

        return Ok(count);
    }

    // [HttpPost]
    // public IActionResult RegisterUser(User user)
    // {
    //     var key = Guid.NewGuid().ToString("N")[..10];

    //     _store.Users.Add(key, user);

    //     return Ok(key);
    // }

    // [HttpGet]
    // // public IActionResult GetMe()
    // // {
    // //     var claims = new List<Claim>()
    // //     {
    // //         new Claim("PhoneNumber", "123221"),
    // //         new Claim(ClaimTypes.Name, "Nuriddin"),
    // //         new Claim(ClaimTypes.SerialNumber, "AA0193667"),
    // //     };

    // //     var claim = new ClaimsIdentity(claims);

    // //     var user = new ClaimsPrincipal(claim);

    // //     return Ok("public data");
    // // }

    // [HttpGet("data")]
    // [TypeFilter(typeof(AuthFilterAttribute))]
    // public IActionResult GetPublicData()
    // { 
    //     return Ok(" private  data");
    // }

}

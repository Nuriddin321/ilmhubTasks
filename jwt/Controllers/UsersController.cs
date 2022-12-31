using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using jwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace jwt.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]

public class UsersController : ControllerBase
{
    private readonly Settings settings;
    public UsersController(IOptions<Settings> options)
    {
        settings = options.Value;
    }

    [HttpGet]
    public IActionResult GetUserName()
    {
        return Ok(User.FindFirst(ClaimTypes.Name)?.Value);
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Login(string username)
    {

        var keyByte = System.Text.Encoding.UTF8.GetBytes(settings.SecurityKey!); // buni program.cs dayam yoziladi , jwt tokenni authenticate qivotkanda 

        var securityKey = new SigningCredentials(new SymmetricSecurityKey(keyByte), SecurityAlgorithms.HmacSha256);

        var security = new JwtSecurityToken(
            issuer: "Project1",
            audience: "Room1", // bu yerga odatda website url manzili beriladi : google.com or localhost
            new Claim[]
            {
                new Claim(ClaimTypes.Name, username)
            },
            expires: DateTime.Now.AddSeconds(15), // odatda 20 minut beriladi
            signingCredentials: securityKey
        );
        var token = new JwtSecurityTokenHandler().WriteToken(security);
        return Ok(token);
    }
}
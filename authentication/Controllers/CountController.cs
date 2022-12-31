using System;
using System.Security.Claims;
using authentication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Name.Controllers;


[Route("api/[controller]")]
[ApiController]

public class CountController : ControllerBase
{
    [HttpGet]
    // [TypeFilter(typeof(AuthAttribute), Arguments = new Object[]{"admin"})]
    [Role("admin")] //bu attribut tepadigi bn bir xil vazifa bajaradi, faqat adminlar kira oladi
    public IActionResult GetCount()
    {
        //some logical code here

        Claim? username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

        return Ok("username is " + username?.Value);
    }

    [HttpGet("user")]
    [Role("admin, user")] 
    public IActionResult GetMe()
    {
        Claim? username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

        return Ok("username is " + username?.Value);
    }
}

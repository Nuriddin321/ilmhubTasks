using Microsoft.AspNetCore.Mvc;
using middleware.Filters;

namespace middleware.Controllers;


[Route("[controller]")]
[ApiController]
[TilFilter]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return RequestCulture.RequestTili switch
        {
            "en" => Ok("inglizcha data  keldi"),
            "uz" => Ok("uzbekcha data  keldi"),
            _ => throw new InvalidOperationException()
        };
    }
}
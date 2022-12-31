namespace attributeTutorial.Controllers;

using attributeTutorial.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CustomAttributeController : ControllerBase
{
   private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public CustomAttributeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager = null)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }


    [HttpGet("publicdata")]
    public IActionResult GetData()
    {
        return Ok("Umumiy data");
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(string name, string password)
    {
        var user = new IdentityUser()
        {
            UserName = name
        };

       
        var roleExist = await _roleManager.RoleExistsAsync("admin");
        if(!roleExist)
        {
           var result =  await _roleManager.CreateAsync(new IdentityRole("admin"));
        }


        await _userManager.CreateAsync(user, password);

        await _userManager.AddToRoleAsync(user, "admin");


        await _signInManager.SignInAsync(user, isPersistent: true);

        return Ok();
    }

    [HttpGet("logout")]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return Ok("user loged out ");
    }

    [HttpGet("secretdata")] 
    [OnlyAdmin]
    public IActionResult GetSecretData()
    {
        return Ok("This is a secret data only for users who authenticated");
    }

    [HttpGet("secretdata2")]
    [IsAdmin(true)]
    public IActionResult GetSecretData2()
    {
        return Ok("second secret data");
    }

}
namespace attributeTutorial.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager = null)
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

        
        // await _signInManager.PasswordSignInAsync(user, password, isPersistent: true, false);
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
    [Authorize(Roles = "admin")]
    // [Authorize(Roles = "admin")]
    public IActionResult GetSecretData()
    {
        return Ok("This is a secret data only for users who authenticated");
    }

}
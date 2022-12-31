using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public UsersController(ILogger<UsersController> logger,
                           SignInManager<IdentityUser> signInManager,
                           UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetData()
    {
        _logger.LogInformation($"User received secret data");

        return Ok("SecretData");
    }
    

    [HttpPost("register")]
    public async ValueTask<IActionResult> RegisterUser(string name, string password)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
        {
            _logger.LogError("Registration failed");
            return BadRequest("wrong input");
        }

        var user = new IdentityUser()
        {
            UserName = name,
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            return BadRequest("User create bo'lmadi");
        }

        _logger.LogInformation("user successfully registrated");
        return Ok($"{name}, {password}");
    }

    [HttpPost("login")]
    public async ValueTask<IActionResult> Login(string name, string password)
    {
        if (string.IsNullOrEmpty(name))
        {
            _logger.LogError("Login failed");
            return BadRequest("wrong input");
        }

        var user = await _userManager.FindByNameAsync(name);

        if (user is null)
        {
            _logger.LogError("wrong input data in Login action");
            return NotFound("User with this name not found");
        }

        // await _signInManager.SignInAsync(user, isPersistent: true);
        
        var result = await _signInManager.PasswordSignInAsync(user, password, true, false);

        if (!result.Succeeded)
        {
            return BadRequest("sign in qilomadi");
        }

        _logger.LogInformation("User successfully logged in");
        return Ok();
    }

    [Authorize]
    [HttpPost("logout")]
    public async ValueTask<IActionResult> LogOut()
    {
        _logger.LogInformation("User logged out");
        await _signInManager.SignOutAsync();
        return Ok();
    }


}
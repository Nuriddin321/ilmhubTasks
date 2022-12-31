using authentication.Dtos;
using authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace authentication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly PathConfig _config;

    public UsersController(IOptions<PathConfig> options)
    {
        _config = options.Value;
    }
    
    [HttpGet]
    public IActionResult GetUsers()
    {
        var readData = System.IO.File.ReadAllText(_config.SaveFolder);
        if(readData is null )
            return NotFound();
        
        var users = JsonConvert.DeserializeObject<List<User>>(readData);

        return Ok(users);
    }

    [HttpPost]
    public IActionResult RegisterUser(UserDto userDto)
    {   
        var user = new User
        {
            Id = Guid.NewGuid().ToString("N"),
            Name = userDto.Name,
            Password = userDto.Password,
            Role = userDto.Role,
            Token = Guid.NewGuid().ToString("N")
        };

        if (!Directory.Exists(_config.AddFolder))
        {
            Directory.CreateDirectory(_config.AddFolder);
        }

        var readData = System.IO.File.ReadAllText(_config.SaveFolder);

        var userList = JsonConvert.DeserializeObject<List<User>>(readData);

        userList.Add(user);

        var data = JsonConvert.SerializeObject(userList);

        System.IO.File.WriteAllText(_config.SaveFolder, data);

        return Ok(user.Token);
    }
}
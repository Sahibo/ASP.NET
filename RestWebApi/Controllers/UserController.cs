using Microsoft.AspNetCore.Mvc;
namespace RestWebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("Hello from UserController");
    }
    
    [HttpGet]
    public IActionResult GetUser([FromHeader]string id)
    {
        return Ok($"Hello from GetUser {id}\n");
    }
    
    [HttpPost]
    public IActionResult Post([FromBody]User user)
    {
        return Ok($"Hello from GetUser {user.Id}\n{user.Name}\n{user.Age}");
    }


}


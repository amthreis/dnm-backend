using Microsoft.AspNetCore.Mvc;
using DoctorsNearMe.Application.Users;
using DoctorsNearMe.Application.Users.Contracts;

namespace DoctorsNearMe.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    readonly ILogger<UserController> _logger;
    readonly IUserService _userService;

    public UserController(
        ILogger<UserController> logger,
        IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListUsers()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        return Ok(await _userService.AddAsync(request));
    }
}

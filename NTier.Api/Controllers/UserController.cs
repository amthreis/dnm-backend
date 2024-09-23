using Microsoft.AspNetCore.Mvc;
using NTier.Application.Services;

namespace NTier.Api.Controllers;

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
}

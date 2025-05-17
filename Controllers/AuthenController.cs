using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Data;
using NorthwindAPI.Models;
using NorthwindAPI.Dto;
using NorthwindAPI.Services;


[Route("api/[controller]")]
[ApiController]
public class AuthenController : ControllerBase
{
    private readonly IAuthService _authenservice;
    public AuthenController(IAuthService authService)
    {
        _authenservice = authService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterService(UserDto request)
    {
        var result = await _authenservice.Register(request);
        return Ok(result);
    }
    [HttpPost("Login")]
    public async Task<IActionResult> LoginService(UserDto request)
    {
        var result = await _authenservice.Login(request);
        return Ok(result);
    }

}
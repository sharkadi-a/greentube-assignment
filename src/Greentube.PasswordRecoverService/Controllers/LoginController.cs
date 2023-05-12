using Greentube.PasswordService.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Greentube.PasswordService.Controllers;

[Route("login")]
public class LoginController : Controller
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public LoginController(IAuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }
    
    [HttpPost]
    [Route("temp/{email}/{secret}")]
    public async Task<IActionResult> TempLogin(string email, string secret)
    {
        var user = await _userService.GetUserByEmail(email);
        await _authService.TempAuth(user, secret);
        return Ok();
    }
}
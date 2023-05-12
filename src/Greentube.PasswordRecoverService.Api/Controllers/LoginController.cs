using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Greentube.PasswordService.Api.Controllers;

[Route("login")]
public class LoginController : Controller
{
    private readonly IUserService _userService;
    private readonly IValidator _validator;
    private readonly IAuthService _authService;

    public LoginController(IAuthService authService, IUserService userService, IValidator validator)
    {
        _authService = authService;
        _userService = userService;
        _validator = validator;
    }
    
    [HttpPost]
    [Route("temp/{email}/{secret}")]
    public async Task<ActionResult<ApiResponse>> TempLogin(string email, string secret)
    {
        _validator.ValidateEmail(email);

        var user = await _userService.GetUserByEmail(email);
        await _authService.TempAuth(user, secret);
        return Ok();
    }
}
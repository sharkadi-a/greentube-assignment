using Greentube.PasswordService.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Greentube.PasswordService.Controllers;

[Route("recover")]
[Produces("application/json")]
public class RecoverPasswordController : Controller
{
    private readonly IUserService _userService;
    private readonly IPasswordService _passwordService;

    public RecoverPasswordController(IUserService userService, IPasswordService passwordService)
    {
        _userService = userService;
        _passwordService = passwordService;
    }
    
    [HttpPost]
    [Route("byEmail/{email}")]
    public async  Task<IActionResult> RecoverUserPassword(string email)
    {
        var user = await _userService.GetUserByEmail(email);
        _passwordService.GenerateResetToken(user)
    }
}
using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Greentube.PasswordService.Api.Controllers;

[Route("recover")]
[Produces("application/json")]
public class RecoverPasswordController : Controller
{
    private readonly IUserService _userService;
    private readonly IPasswordService _passwordService;
    private readonly IEmailService _emailService;
    private readonly IEmailFactory _emailFactory;
    private readonly IValidator _validator;

    public RecoverPasswordController(IUserService userService, IPasswordService passwordService,
        IEmailService emailService, IEmailFactory emailFactory, IValidator validator)
    {
        _userService = userService;
        _passwordService = passwordService;
        _emailService = emailService;
        _emailFactory = emailFactory;
        _validator = validator;
    }

    [HttpPost]
    [Route("byEmail/{email}")]
    public async Task<ActionResult<ApiResponse>> RecoverUserPassword(string email)
    {
        _validator.ValidateEmail(email);
        
        var user = await _userService.GetUserByEmail(email);
        var token = await _passwordService.GenerateResetToken(user);
        
        var request = HttpContext.Request;
        var link = $"{request.Scheme}://{request.Host}{request.PathBase}/login/temp/{email}/{token}";

        var emailMessage = _emailFactory.CreateResetPasswordEmail(user, link);
        await _emailService.SendTemplateEmail(emailMessage);
        return Ok();
    }
}
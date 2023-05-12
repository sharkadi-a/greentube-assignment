using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.Exceptions;
using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Services;

public class SimpleAuthService : IAuthService
{
    private readonly IPasswordService _passwordService;

    public SimpleAuthService(IPasswordService passwordService)
    {
        _passwordService = passwordService;

    }
    
    public async Task TempAuth(UserModel user, string tempToken)
    {
        if (! await _passwordService.VerifyToken(tempToken, user.Email))
        {
            throw new InvalidTempAuthToken();
        }

        await LoginByEmailAddress(user.Email);
    }

    private Task LoginByEmailAddress(string email)
    {
        return Task.CompletedTask;
    }
}
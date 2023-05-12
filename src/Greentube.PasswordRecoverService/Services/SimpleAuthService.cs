using Greentube.PasswordService.Abstractions;
using Greentube.PasswordService.Exceptions;
using Greentube.PasswordService.Models;

namespace Greentube.PasswordService.Services;

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
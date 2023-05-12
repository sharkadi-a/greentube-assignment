using Greentube.PasswordService.Abstractions;
using Greentube.PasswordService.Models;
using Greentube.PasswordService.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Greentube.PasswordService.Services;

public class SimplePasswordService : IPasswordService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IOptions<PasswordOptions> _options;
    private readonly Random _random = new();

    public SimplePasswordService(IMemoryCache memoryCache, IOptions<PasswordOptions> options)
    {
        _memoryCache = memoryCache;
        _options = options;
    }

    public Task<string> GenerateResetToken(UserModel user)
    {
        var token = GenerateToken();
        _memoryCache.Set(user.Email, token, _options.Value.ResetPasswordLifetime);
        
        return Task.FromResult(token);
    }

    public Task<bool> VerifyToken(string token, string email)
    {
        var actualToken = _memoryCache.Get<string>(email);
        return Task.FromResult(!string.IsNullOrEmpty(actualToken) && actualToken == token);
    }

    private string GenerateToken()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, _options.Value.ResetTokenLength)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}
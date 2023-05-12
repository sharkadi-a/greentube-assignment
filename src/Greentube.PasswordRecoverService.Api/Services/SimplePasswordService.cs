using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.Models;
using Greentube.PasswordService.Api.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Greentube.PasswordService.Api.Services;

internal class SimplePasswordService : IPasswordService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IOptions<PasswordOptions> _options;
    private readonly Random _random = new();

    public SimplePasswordService(IMemoryCache memoryCache, IOptions<PasswordOptions> options)
    {
        _memoryCache = memoryCache;
        _options = options;
    }

    public Task<string> GenerateTemporaryToken(UserModel user)
    {
        var token = GenerateToken();
        _memoryCache.Set(user.Email, token, _options.Value.ResetPasswordTokenLifetime);
        
        return Task.FromResult(token);
    }

    public Task<bool> VerifyTokenOnce(string token, string email)
    {
        var result = _memoryCache.TryGetValue<string>(email, out var actualToken) &&
                     !string.IsNullOrEmpty(actualToken) && actualToken == token;

        return Task.FromResult(result);
    }

    private string GenerateToken()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, _options.Value.ResetTokenLength)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}
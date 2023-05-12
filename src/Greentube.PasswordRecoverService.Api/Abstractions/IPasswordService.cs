using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Abstractions;

/// <summary>
/// Service to maintain passwords
/// </summary>
public interface IPasswordService
{
    /// <summary>
    /// Creates a temporary token to perform single sign-in.
    /// </summary>
    /// <param name="user">User that requested password recover</param>
    /// <returns>The token</returns>
    Task<string> GenerateTemporaryToken(UserModel user);
    
    /// <summary>
    /// Verifies token against E-mail once and makes it obsolete
    /// </summary>
    /// <param name="token">The token</param>
    /// <param name="email">E-mail to be verified for the token</param>
    /// <returns>True, is succeed</returns>
    Task<bool> VerifyTokenOnce(string token, string email);
}
using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Abstractions;

/// <summary>
/// Authentication service
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Authenticates user with temporary token
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="tempToken">Temporary token</param>
    Task TempAuth(UserModel user, string tempToken);
}
using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Abstractions;

/// <summary>
/// Service to maintain users.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Create a user, does nothing if user already exists.
    /// </summary>
    /// <param name="user">The user</param>
    Task CreateUser(UserModel user);
    
    /// <summary>
    /// Get a user by E-mail.
    /// </summary>
    /// <param name="email">User's E-mail</param>
    /// <returns>The user</returns>
    Task<UserModel> GetUserByEmail(string email);
}
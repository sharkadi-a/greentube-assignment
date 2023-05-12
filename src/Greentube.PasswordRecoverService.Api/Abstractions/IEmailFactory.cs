using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Abstractions;

/// <summary>
/// Factory to create E-mail messages
/// </summary>
public interface IEmailFactory
{
    /// <summary>
    /// Creates the "reset password" E-mail
    /// </summary>
    /// <param name="user">User to send E-mail to</param>
    /// <param name="link">Link for temporary authentication</param>
    /// <returns>Email message</returns>
    EmailMessageModel CreateResetPasswordEmail(UserModel user, string link);
}
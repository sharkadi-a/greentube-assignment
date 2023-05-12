using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Abstractions;

/// <summary>
/// E-mail service to send mail
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Sends E-mail
    /// </summary>
    /// <param name="messageModel">E-mail to send</param>
    Task Send(EmailMessageModel messageModel);
}
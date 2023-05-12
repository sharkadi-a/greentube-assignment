using Greentube.PasswordService.Models;

namespace Greentube.PasswordService.Abstractions;

public interface IEmailService
{
    Task SendTemplateEmail(EmailMessageModel messageModel);
}
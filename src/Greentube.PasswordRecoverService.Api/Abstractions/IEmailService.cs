using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Abstractions;

public interface IEmailService
{
    Task SendTemplateEmail(EmailMessageModel messageModel);
    
}
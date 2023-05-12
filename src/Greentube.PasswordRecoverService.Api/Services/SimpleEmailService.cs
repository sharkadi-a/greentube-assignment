using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Services;

public class SimpleEmailService : IEmailService
{
    private readonly ICollection<EmailMessageModel> _emailsSent = new LinkedList<EmailMessageModel>();

    public Task SendTemplateEmail(EmailMessageModel messageModel)
    {
        _emailsSent.Add(messageModel);
        return Task.CompletedTask;
    }
}
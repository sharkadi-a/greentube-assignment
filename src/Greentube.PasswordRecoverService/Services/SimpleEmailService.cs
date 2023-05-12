using Greentube.PasswordService.Abstractions;
using Greentube.PasswordService.Models;

namespace Greentube.PasswordService.Services;

public class SimpleEmailService : IEmailService
{
    private readonly ICollection<EmailMessageModel> _emailsSent = new LinkedList<EmailMessageModel>();

    public Task SendTemplateEmail(EmailMessageModel messageModel)
    {
        _emailsSent.Add(messageModel);
        return Task.CompletedTask;
    }
}
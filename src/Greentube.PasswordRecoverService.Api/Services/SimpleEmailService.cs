using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Services;

internal class SimpleEmailService : IEmailService
{
    private readonly ICollection<EmailMessageModel> _emailsSent = new LinkedList<EmailMessageModel>();

    public Task Send(EmailMessageModel messageModel)
    {
        _emailsSent.Add(messageModel);
        return Task.CompletedTask;
    }
}
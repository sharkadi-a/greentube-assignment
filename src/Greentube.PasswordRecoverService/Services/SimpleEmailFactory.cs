using Greentube.PasswordService.Abstractions;
using Greentube.PasswordService.Models;

namespace Greentube.PasswordService.Services;

public class SimpleEmailFactory : IEmailFactory
{
    private const string ResetPasswordTemplate =
        "<!DOCTYPE html><html><head><title>Login to Change Password</title></head>" +
        "<body><p>Dear player,</p><p>In order to log in to your account so you can change your password click the following link:" +
        "</p><a href=\"{0}\">{1}</a><p>Note that this link is only valid for 1 hour, after which it expires!</p>" +
        "<p>Happy playing!</p><p>Greentube Support Team</p></body></html>";
    
    public EmailMessageModel CreateResetPasswordEmail(UserModel user, string link)
    {
        return new EmailMessageModel(user, string.Format(ResetPasswordTemplate, link, link));
    }
}
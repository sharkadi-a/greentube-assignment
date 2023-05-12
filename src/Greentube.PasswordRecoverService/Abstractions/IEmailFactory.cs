using Greentube.PasswordService.Models;

namespace Greentube.PasswordService.Abstractions;

public interface IEmailFactory
{
    EmailMessageModel CreateResetPasswordEmail(UserModel user, string link);
}
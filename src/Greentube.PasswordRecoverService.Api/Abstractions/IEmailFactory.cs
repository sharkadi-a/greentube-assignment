using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Abstractions;

public interface IEmailFactory
{
    EmailMessageModel CreateResetPasswordEmail(UserModel user, string link);
}
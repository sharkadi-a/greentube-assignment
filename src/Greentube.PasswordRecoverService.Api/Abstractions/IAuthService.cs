using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Abstractions;

public interface IAuthService
{
    Task TempAuth(UserModel user, string tempToken);
}
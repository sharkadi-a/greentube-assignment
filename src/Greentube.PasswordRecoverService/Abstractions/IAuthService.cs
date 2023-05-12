using Greentube.PasswordService.Models;

namespace Greentube.PasswordService.Abstractions;

public interface IAuthService
{
    Task TempAuth(UserModel user, string tempToken);
}
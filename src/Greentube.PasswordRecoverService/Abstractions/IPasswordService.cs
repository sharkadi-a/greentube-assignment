using Greentube.PasswordService.Models;

namespace Greentube.PasswordService.Abstractions;

public interface IPasswordService
{
    Task<string> GenerateResetToken(UserModel user);
    Task<bool> VerifyToken(string token, string email);
}
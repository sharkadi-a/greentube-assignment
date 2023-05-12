using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Abstractions;

public interface IPasswordService
{
    Task<string> GenerateResetToken(UserModel user);
    Task<bool> VerifyTokenOnce(string token, string email);
}
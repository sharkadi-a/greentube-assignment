using Greentube.PasswordService.Models;

namespace Greentube.PasswordService.Abstractions;

public interface IUserService
{
    Task<UserModel> CreateUser(string name, string email);
    Task<UserModel> GetUserByEmail(string email);
}
using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Abstractions;

public interface IUserService
{
    Task<UserModel> CreateUser(string name, string email);
    Task<UserModel> GetUserByEmail(string email);
}
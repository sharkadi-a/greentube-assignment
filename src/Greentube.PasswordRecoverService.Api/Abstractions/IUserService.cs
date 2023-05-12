using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Abstractions;

public interface IUserService
{
    Task<UserModel> CreateUser(UserModel user);
    Task<UserModel> GetUserByEmail(string email);
}
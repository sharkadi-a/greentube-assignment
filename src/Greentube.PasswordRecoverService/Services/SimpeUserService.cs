using Greentube.PasswordService.Abstractions;
using Greentube.PasswordService.Exceptions;
using Greentube.PasswordService.Models;

namespace Greentube.PasswordService.Services;

public class SimpeUserService : IUserService
{
    private readonly ISet<UserModel> _users = new HashSet<UserModel>();

    public Task<UserModel> CreateUser(string name, string email)
    {
        var user = new UserModel(name, email);
        _users.Add(user);

        return Task.FromResult(user);
    }

    public Task<UserModel> GetUserByEmail(string email)
    {
        var user = _users.FirstOrDefault(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));

        if (user is null)
        {
            throw new UserNotFoundException();
        }

        return Task.FromResult(user);
    }
}
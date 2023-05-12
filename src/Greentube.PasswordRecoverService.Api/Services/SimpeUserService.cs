using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.Exceptions;
using Greentube.PasswordService.Api.Models;

namespace Greentube.PasswordService.Api.Services;

internal class SimpeUserService : IUserService
{
    private readonly ISet<UserModel> _users = new HashSet<UserModel>();

    public Task CreateUser(UserModel user)
    {
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
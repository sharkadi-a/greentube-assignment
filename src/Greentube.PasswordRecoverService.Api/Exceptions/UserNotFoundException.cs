namespace Greentube.PasswordService.Api.Exceptions;

/// <summary>
/// User was not found exception
/// </summary>
public class UserNotFoundException : ServiceException
{
    public override string Message => "User does not exist";
}
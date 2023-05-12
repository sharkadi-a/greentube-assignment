namespace Greentube.PasswordService.Api.Exceptions;

public class UserNotFoundException : ServiceException
{
    public override string Message => "User does not exist";
}
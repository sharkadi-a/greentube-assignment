namespace Greentube.PasswordService.Exceptions;

public class UserNotFoundException : Exception
{
    public override string Message => "User does not exist";
}
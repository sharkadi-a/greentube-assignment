namespace Greentube.PasswordService.Api.Exceptions;

public class InvalidEmailException : ServiceException
{
    public override string Message => "Provided email is invalid";
}
namespace Greentube.PasswordService.Api.Exceptions;

/// <summary>
/// Invalid E-mail value exception
/// </summary>
public class InvalidEmailException : ServiceException
{
    public override string Message => "Provided email is invalid";
}
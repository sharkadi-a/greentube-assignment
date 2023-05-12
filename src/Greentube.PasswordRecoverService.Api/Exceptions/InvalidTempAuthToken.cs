namespace Greentube.PasswordService.Api.Exceptions;

public class InvalidTempAuthToken : ServiceException
{
    public override string Message => "Invalid temp auth token provided";
}
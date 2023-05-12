namespace Greentube.PasswordService.Exceptions;

public class InvalidTempAuthToken : Exception
{
    public override string Message => "Invalid temp auth token provided";
}
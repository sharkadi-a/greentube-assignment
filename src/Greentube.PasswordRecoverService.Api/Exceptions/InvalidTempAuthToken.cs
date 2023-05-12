namespace Greentube.PasswordService.Api.Exceptions;

/// <summary>
/// Invalid temporary token exception
/// </summary>
public class InvalidTempAuthToken : ServiceException
{
    public override string Message => "Invalid temp auth token provided";
}
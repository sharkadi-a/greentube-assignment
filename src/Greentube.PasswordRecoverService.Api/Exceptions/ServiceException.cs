namespace Greentube.PasswordService.Api.Exceptions;

/// <summary>
/// Service exception.
/// </summary>
public abstract class ServiceException : Exception
{
    public virtual int HttpResponse => 400;
}
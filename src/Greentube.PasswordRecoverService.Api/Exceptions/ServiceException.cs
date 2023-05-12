namespace Greentube.PasswordService.Api.Exceptions;

public abstract class ServiceException : Exception
{
    public virtual int HttpResponse { get; } = 400;
}
namespace Greentube.PasswordService.Api.Abstractions;

public interface IValidator
{
    public void ValidateEmail(string email);
}
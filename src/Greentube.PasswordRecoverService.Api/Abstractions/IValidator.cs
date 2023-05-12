namespace Greentube.PasswordService.Api.Abstractions;

/// <summary>
/// Input parameters validator
/// </summary>
public interface IValidator
{
    /// <summary>
    /// Validates E-mail value.
    /// </summary>
    public void ValidateEmail(string email);
}
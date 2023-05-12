namespace Greentube.PasswordService.Api.Options;

public class PasswordOptions
{
    public TimeSpan ResetPasswordLifetime { get; set; }
    public int ResetTokenLength { get; set; }
}
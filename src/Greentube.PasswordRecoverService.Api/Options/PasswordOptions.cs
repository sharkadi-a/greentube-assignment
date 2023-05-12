namespace Greentube.PasswordService.Api.Options;

/// <summary>
/// Password options
/// </summary>
public class PasswordOptions
{
    /// <summary>
    /// Sets the reset token lifetime (a temporary token)
    /// </summary>
    public TimeSpan ResetPasswordTokenLifetime { get; set; }
    
    /// <summary>
    /// Length of the token
    /// </summary>
    public int ResetTokenLength { get; set; }
}
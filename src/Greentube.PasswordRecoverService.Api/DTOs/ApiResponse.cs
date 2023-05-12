namespace Greentube.PasswordService.Api.DTOs;

/// <summary>
/// Response from the API
/// </summary>
public class ApiResponse
{
    /// <summary>
    /// An error, if any
    /// </summary>
    public string? Error { get; set; }
}
using System.Text.RegularExpressions;
using Greentube.PasswordService.Api.Abstractions;
using Greentube.PasswordService.Api.Exceptions;

namespace Greentube.PasswordService.Api.Services;

internal class SimpleValidator : IValidator
{
    private readonly static Regex EmailRegex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.Compiled);
    
    public void ValidateEmail(string email)
    {
        if (!EmailRegex.IsMatch(email))
        {
            throw new InvalidEmailException();
        }
    }
}
namespace Greentube.PasswordService.Api.Models;

/// <summary>
/// E-mail message
/// </summary>
public class EmailMessageModel : IEquatable<EmailMessageModel>
{
    public EmailMessageModel(UserModel to, string htmlBody)
    {
        To = to;
        HtmlBody = htmlBody;
    }

    /// <summary>
    /// Receiver of the E-mail
    /// </summary>
    public UserModel To { get; }
    
    /// <summary>
    /// E-mail body as HTML
    /// </summary>
    public string HtmlBody { get; }

    public bool Equals(EmailMessageModel? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return To.Equals(other.To) && HtmlBody == other.HtmlBody;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != this.GetType())
        {
            return false;
        }

        return Equals((EmailMessageModel)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(To, HtmlBody);
    }
}
namespace Greentube.PasswordService.Api.Models;

public class EmailMessageModel : IEquatable<EmailMessageModel>
{
    public EmailMessageModel(UserModel to, string body)
    {
        To = to;
        Body = body;
    }

    public UserModel To { get; }
    public string Body { get; }

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

        return To.Equals(other.To) && Body == other.Body;
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
        return HashCode.Combine(To, Body);
    }
}
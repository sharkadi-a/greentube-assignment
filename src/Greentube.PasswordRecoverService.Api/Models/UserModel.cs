namespace Greentube.PasswordService.Api.Models;

/// <summary>
/// A user
/// </summary>
public class UserModel : IEquatable<UserModel>
{
    public UserModel(string name, string email)
    {
        Name = name;
        Email = email;
    }

    /// <summary>
    /// User's name
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// User's E-mail
    /// </summary>
    public string Email { get;  }

    public bool Equals(UserModel? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Name == other.Name && Email == other.Email;
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

        return Equals((UserModel)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Email);
    }
}
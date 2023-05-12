namespace Greentube.PasswordService.Api.Models;

public class EmailMessageModel
{
    public EmailMessageModel(UserModel to, string body)
    {
        To = to;
        Body = body;
    }

    public UserModel To { get; }
    public string Body { get; }
}
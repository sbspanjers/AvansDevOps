using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Models;

public class Comment
{
    public string Text { get; set; } = string.Empty;
    public User User { get; set; } = null!;

    public Comment(string text, User user)
    {
        this.Text = text;
        this.User = user;
    }

    public static Comment CreateComment(string text, User user)
    {
        return new Comment(text, user);
    }

}
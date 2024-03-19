namespace AvansDevOps.Domain.Models;

public class Forum
{
    public List<ReviewThread> Threads { get; set; }

    public Forum()
    {
        this.Threads = new List<ReviewThread>();
    }
}

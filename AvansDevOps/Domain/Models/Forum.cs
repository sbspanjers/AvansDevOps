namespace AvansDevOps.Domain.Models;

public class Forum
{
    public List<ReviewThread> Threads { get; set; }

    public Forum()
    {
        this.Threads = new List<ReviewThread>();
    }
    public override string ToString()
    {
        //Return each thread in the forum by name and the contents
        return string.Join("\n", this.Threads.Select(thread => thread.ToString()));
    }
}

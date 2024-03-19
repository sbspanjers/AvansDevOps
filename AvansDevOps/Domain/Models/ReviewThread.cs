namespace AvansDevOps.Domain.Models;

public class ReviewThread
{    
    public string Title { get; set; } = string.Empty;
    public List<Comment> Comments = new();
    public BacklogItem BacklogItem  { get; set; } = null!;
}
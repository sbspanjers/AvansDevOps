namespace AvansDevOps.Domain.Models;

public class ReviewThread
{
    private List<Comment> _comments = new();
    private BacklogItem _backlogItem;
}
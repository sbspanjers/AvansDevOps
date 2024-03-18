using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Models;

public class BacklogItem
{
    private string _name;
    private string _description;
    private List<SubTask> subTasks = new();
    private Sprint _sprint;
    private IBacklogitemState _state;
    private Project _project;
    private ReviewThread _reviewThread;
}
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Users;

namespace AvansDevOps.Domain.Models;

public class Project
{
    private List<Sprint> _sprints;
    private List<BacklogItem> _backlogItems;
    private string _name;
    private IGit _gitFunctions;
    private SprintFactory _sprintFactory;
    private ProductOwner ProductOwner;
    public Pipeline Pipeline { get; set; }

    public Project(string name, Pipeline pipeline, IGit git)
    {
        this.Pipeline = pipeline;
        this._gitFunctions = git;
        this._name = name;
        this._backlogItems = new();
        this._sprints = new();
    }
    public void CreateSprint(string name, DateTime startDate, DateTime endDate)
    {
        Sprint sprint = this._sprintFactory.CreateSprint(name, startDate, endDate);
        this._sprints.Add(sprint);
    }

    public BacklogItem AddBacklogItem(BacklogItem backlogItem)
    {
        this._backlogItems.Add(backlogItem);
        return backlogItem;
    }

    public void SetSprintFactory(SprintFactory sprintFactory)
    {
        this._sprintFactory = sprintFactory;
    }

    public List<BacklogItem> GetBacklogItems()
    {
        //sort on backlog name
        return this._backlogItems.OrderBy(x => x.getName()).ToList();
    }

    public BacklogItem GetBacklogItem(string name)
    {
        return this._backlogItems.FirstOrDefault(x => x.getName() == name)!;
    }

    public BacklogItem EditBacklogItem(string name, string description, List<SubTask> list)
    {
        var current = this._backlogItems.FirstOrDefault(x => x.getName() == name);
        current!.Edit(name, description, list);
        return current;
    }

    public Sprint GetSprint(string name)
    {
        return this._sprints.FirstOrDefault(x => x.Name == name)!;
    }
}

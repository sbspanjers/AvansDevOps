using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.States.BacklogitemStates;

namespace AvansDevOps.Domain.Models;

public class BacklogItem
{
    private string _name;
    private string _description;
    private List<SubTask> _subTasks;
    public Sprint Sprint { get; set; }
    public IBacklogitemState State { get; private set; }
    private Project _project;
    public ReviewThread ReviewThread { get; set; } = null!;

    public BacklogItem(string name, string description, Project project)
    { 
        _subTasks = new List<SubTask>();
        State = new ToDoState(this);

        _name = name;
        _description = description;
        _project = project;
    }
    public string getName()
    {
        return _name;
    }

    public void SetState(IBacklogitemState state)
    {
        State = state;
    }

    public void NextState()
    {
        State.NextPhase();
    }

    public void SetSprint(Sprint sprint)
    {
        Sprint = sprint;
    }

    public void Edit(string name, string description, List<SubTask> subTasks)
    {
        this._name = name;
        this._description = description;
        this._subTasks = subTasks;
    }

    public override string ToString()
    {
        //Name, description , subtasks if any

        return $"{_name} - {_description} - {string.Join(",", _subTasks.Select(x => x.Name))}";

    }
}
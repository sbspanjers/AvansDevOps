using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Models;

public class BacklogItem
{
    private string _name ;
    private string _description;
    private List<SubTask> _subTasks;
    private Sprint _sprint;
    private IBacklogitemState _state;
    private Project _project;
    private ReviewThread _reviewThread;

    public BacklogItem(string name, string description, Project project) { 

        //Default values
        _reviewThread = new ReviewThread();
        _subTasks = new List<SubTask>();
        
        //_state = new ToDoState();

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
        _state = state;
    }



    public void SetSprint(Sprint sprint)
    {
        _sprint = sprint;
    }

    public void Edit(string name, string description, List<SubTask> subTasks)
    {
        this._name = name;
        this._description = description;
        this._subTasks = subTasks;
    }

}
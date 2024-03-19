using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Observer;

namespace AvansDevOps.Domain.Interfaces;
public abstract class Sprint
{
    protected ISprintState _sprintState;
    
    private IExportMethod _exportMethod;
    private Publisher _publisher;

    public string Name { get; set;} = string.Empty;
    public DateTime StartDate { get; set;}
    public DateTime EndDate { get; set;}
    public List<BacklogItem> BacklogItems { get; set;}
    public Pipeline Pipeline { get; set;}
    public List<User> Users { get; set;}
    
    public Sprint() { }

    public Sprint(string name, DateTime startDate, DateTime endDate)
    {
        this.Name = name;
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.BacklogItems = new List<BacklogItem>();
        this.Users = new List<User>();
    }
   

    public void SetSprintState(ISprintState sprintState)
    {
        this._sprintState = sprintState;
    }

    public void AddBacklogItem(BacklogItem backlogItem)
    {
        BacklogItems.Add(backlogItem);
    }

    public Sprint EditSprint(string name, DateTime startDate, DateTime endDate)
    {
        return this._sprintState.EditSprintMetaData(name, startDate, endDate);
    }

    public void NextPhase()
    {
        this._sprintState.NextPhase();
    }

    public void AddUserToSprint(User user)
    {
        this.Users.Add(user);
    }

    public void GenerateReport()
    {
        this._exportMethod.Export();
    }

    public abstract void FinishSprint();
    public abstract void CreateReview(string message);
}

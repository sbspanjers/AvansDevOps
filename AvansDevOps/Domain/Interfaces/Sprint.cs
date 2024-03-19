using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.States.SprintStates;

namespace AvansDevOps.Domain.Interfaces;
public abstract class Sprint : IPublisher
{
    protected ISprintState _sprintState;
    
    private IExportMethod _exportMethod;

    public string Name { get; set;} = string.Empty;
    public DateTime StartDate { get; set;}
    public DateTime EndDate { get; set;}
    public List<BacklogItem> BacklogItems { get; set;}
    public Pipeline Pipeline { get; set;}
    public List<User> Users { get; set;}

    private List<ISubscriber> _subscribers = new();
    
    public Sprint() { }

    public Sprint(string name, DateTime startDate, DateTime endDate)
    {
        this.Name = name;
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.BacklogItems = new List<BacklogItem>();
        this.Users = new List<User>();
        this._sprintState = new CreatedState(this);
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

    public void AddSubscriber(ISubscriber subscriber)
    {
        this._subscribers.Add(subscriber);
    }

    public void RemoveSubscriber(ISubscriber subscriber)
    {
        this._subscribers.Remove(subscriber);
    }

    public void NotifySubscribers(string message, INotifyRule notifyRule)
    {
        var users = notifyRule.Filter(this.Users);

        foreach (var user in users)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Notify(message, user.Name);
            }
        }
    }

    public override string ToString()
    {
        //Return the name, start date and end date of the sprint and the current state of the sprint  and the backlog items by name and description each one should start on a new line
        return $"Sprint: {this.Name}\nStart date: {this.StartDate}\nEnd date: {this.EndDate}\nState: {this._sprintState}\nBacklog items:\n{string.Join("\n", this.BacklogItems.Select(x => x.ToString()))}";
    }
}

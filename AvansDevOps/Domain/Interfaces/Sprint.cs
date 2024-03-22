using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.States.SprintStates;
using AvansDevOps.Domain.Users;

namespace AvansDevOps.Domain.Interfaces;
public abstract class Sprint : IPublisher
{
    protected ISprintState _sprintState;


    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<BacklogItem> BacklogItems { get; set; }
    public Pipeline Pipeline { get; set; }
    public List<User> Users { get; set; }

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


    public ISprintState SetSprintState(ISprintState sprintState)
    {
        this._sprintState = sprintState;
        return sprintState;
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

    public bool AddUserToSprint(User user)
    {
        if (user is Scrummaster && this.Users.Any(x => x is Scrummaster))
        {
            Console.WriteLine($"{user.Name} is not able to add to sprint as Scrummaster");
        }
        else
        {
            //Only add the user if it is not already in the list
            if (!this.Users.Contains(user))
            {
                this.Users.Add(user);
                return true;
            }
        }
        return false;
    }

    public void GenerateReport(IExportMethod method)
    {
        method.Export(this);
    }

    public abstract bool FinishSprint(bool deploySuccess);
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

    public ISprintState GetState()
    {
        return this._sprintState;
    }
}

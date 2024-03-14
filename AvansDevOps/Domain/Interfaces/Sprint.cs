namespace AvansDevOps.Domain.Interfaces;

public abstract class Sprint
{
    private ISprintState _sprintState;

    private string _name;
    private DateTime _startDate;
    private DateTime _endDate;

    // backlogitems
    // exportmethod
    // publisher

    public void SetSprintState(ISprintState sprintState)
    {
        this._sprintState = sprintState;
    }

    public void FinishSprint()
    {
        // of reviewsprint
        // of deploymentsprint
    }

    public void GenerateReport()
    {
        // exportmethod
    }
    public abstract void Upload();
    public abstract void Deploy();  
}

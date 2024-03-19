using AvansDevOps.Domain.Observer;

namespace AvansDevOps.Domain.Interfaces;
public abstract class Sprint
{
    private ISprintState _sprintState;

    private string _name;
    private DateTime _startDate;
    private DateTime _endDate;


    // backlogitems
    // exportmethod
    private Publisher _publisher;

    public Sprint() { }

    public Sprint(string name, DateTime startDate, DateTime endDate)
    {
        this._name = name;
        this._startDate = startDate;
        this._endDate = endDate;
    }
   

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

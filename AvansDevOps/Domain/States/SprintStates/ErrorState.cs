using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.States.SprintStates;

public class ErrorState : ISprintState
{
    private Sprint _sprint;

    public ErrorState(Sprint sprint)
    {
        _sprint = sprint;
    }

    public void CreateReview(string message)
    {
        Console.WriteLine("Review not possible.");
    }

    public Sprint EditSprintMetaData(string name, DateTime startDate, DateTime endDate)
    {
        this._sprint.Name = name;
        return this._sprint;
    }

    public void FinishSprint()
    {
        Console.WriteLine("Finish sprint not possible.");
    }

    public void GotToAfterFinishedState()
    {
        Console.WriteLine("Releasing again");
        this._sprint.SetSprintState(new AfterFinishedState(this._sprint)).FinishSprint();
    }

    public void NextPhase()
    {

        //Go to cancel
        this._sprint.SetSprintState(new CanceledState(this._sprint));
    }

    public override string ToString()
    {
        return "ErrorState";
    }
}

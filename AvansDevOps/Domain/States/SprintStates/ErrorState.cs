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

    public void GotToFinishedState()
    {
        this._sprint.SetSprintState(new FinishedState(this._sprint));
    }

    public void NextPhase()
    {
        Console.WriteLine("Sprint is in error state.");
    }

    public override string ToString()
    {
        return "ErrorState";
    }
}

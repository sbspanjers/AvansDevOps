using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.States.SprintStates;

public class CreatedState : ISprintState
{
    private Sprint _sprint;

    public CreatedState(Sprint sprint)
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
        this._sprint.StartDate = startDate;
        this._sprint.EndDate = endDate;

        return this._sprint;
    }

    public void FinishSprint()
    {
        throw new NotImplementedException();
    }

    public void GotToAfterFinishedState()
    {
        Console.WriteLine("Sprint is not started yet.");
    }

    public void NextPhase()
    {
        this._sprint.SetSprintState(new StartedState(this._sprint));
    }

    public override string ToString()
    {
        return "CreatedState";
    }
}

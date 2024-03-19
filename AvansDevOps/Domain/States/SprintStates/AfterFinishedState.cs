using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.States.SprintStates;

public class AfterFinishedState : ISprintState
{
    private Sprint _sprint;

    public AfterFinishedState(Sprint sprint)
    {
        _sprint = sprint;
        FinishSprint();
    }

    private void FinishSprint()
    {
        this._sprint.FinishSprint();
    }

    public Sprint EditSprintMetaData(string name, DateTime startDate, DateTime endDate)
    {
        this._sprint.Name = name;
        return this._sprint;
    }

    public void GotToFinishedState()
    {
        Console.WriteLine("Sprint is already finished.");
    }

    public void NextPhase()
    {
        this._sprint.SetSprintState(new ClosedState(this._sprint));
    }

    public override string ToString()
    {
        return "AfterFinishedState";
    }

    public void CreateReview(string message)
    {
        Console.WriteLine("Review not possible.");
    }
}

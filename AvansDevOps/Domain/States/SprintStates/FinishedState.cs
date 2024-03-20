using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.States.SprintStates;

public class FinishedState : ISprintState
{
    private Sprint _sprint;

    public FinishedState(Sprint sprint)
    {
        _sprint = sprint;
    }

    public Sprint EditSprintMetaData(string name, DateTime startDate, DateTime endDate)
    {
        this._sprint.Name = name;
        return this._sprint;
    }

    public void GotToAfterFinishedState()
    {
        Console.WriteLine("Sprint already in finished state.");
    }

    public void NextPhase()
    {   

        this._sprint.SetSprintState(new AfterFinishedState(this._sprint)).FinishSprint();
    }

    public override string ToString()
    {
        return "FinishedState";
    }

    public void CreateReview(string message)
    {
        this._sprint.CreateReview(message);
    }

    public void FinishSprint()
    {
        throw new NotImplementedException();
    }
}

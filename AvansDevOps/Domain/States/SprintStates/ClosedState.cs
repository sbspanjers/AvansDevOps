using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.States.SprintStates;

public class ClosedState : ISprintState
{
    private Sprint _sprint;

    public ClosedState(Sprint sprint)
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
        throw new NotImplementedException();
    }

    public void GotToAfterFinishedState()
    {
        Console.WriteLine("Sprint is already closed.");
    }

    public void NextPhase()
    {
        Console.WriteLine("Sprint is already closed");
    }

    public override string ToString()
    {
        return "ClosedState";
    }

    public void UploadDocument(string documentName, string documentContent)
    {
        Console.WriteLine("Sprint is already closed.");
    }
}

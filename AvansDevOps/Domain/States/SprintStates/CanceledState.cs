using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.States.SprintStates;

public class CanceledState : ISprintState
{
    private Sprint _sprint;

    public CanceledState(Sprint sprint)
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

    public void FinishSprint(bool deploySuccess)
    {
        throw new NotImplementedException();
    }

    public void GotToAfterFinishedState(bool deploySuccess)
    {
        Console.WriteLine("Sprint is already cancelled.");
    }

    public void NextPhase()
    {
        Console.WriteLine("Sprint is already cancelled.");
    }

    public override string ToString()
    {
        return "CanceledState";
    }

    public void UploadDocument(string documentName, string documentContent)
    {
        throw new NotImplementedException();
    }
}

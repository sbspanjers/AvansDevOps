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

    public void FinishSprint(bool deploySuccess)
    {
        Console.WriteLine("Finish sprint not possible.");
    }

    public void GotToAfterFinishedState(bool deploySuccess)
    {
        Console.WriteLine("Releasing again");
        this._sprint.SetSprintState(new AfterFinishedState(this._sprint)).FinishSprint(deploySuccess);
    }

    public void NextPhase()
    {
        this._sprint.SetSprintState(new CanceledState(this._sprint));
    }

    public override string ToString()
    {
        return "ErrorState";
    }

    public void UploadDocument(string documentName, string documentContent)
    {
        throw new NotImplementedException();
    }
}

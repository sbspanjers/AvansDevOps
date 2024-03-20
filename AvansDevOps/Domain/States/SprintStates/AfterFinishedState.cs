using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.States.SprintStates;

public class AfterFinishedState : ISprintState
{
    private Sprint _sprint;
    private bool deploySucces = false;
    public AfterFinishedState(Sprint sprint)
    {
        _sprint = sprint;
    }

    public void FinishSprint()
    {
        deploySucces = this._sprint.FinishSprint();
        if (!deploySucces)
        {
            this._sprint.SetSprintState(new ErrorState(this._sprint));
        }
        else
        {
            this._sprint.SetSprintState(new ClosedState(this._sprint));
        }

    }

    public Sprint EditSprintMetaData(string name, DateTime startDate, DateTime endDate)
    {
        this._sprint.Name = name;
        return this._sprint;
    }

    public void GotToAfterFinishedState()
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

    public void UploadDocument(string documentName, string documentContent)
    {
        
    }
}

﻿using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.States.SprintStates;

public class StartedState : ISprintState
{
    private Sprint _sprint;    

    public StartedState(Sprint sprint)
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
        Console.WriteLine("Sprint is in started state.");
    }

    public void NextPhase()
    {
        this._sprint.SetSprintState(new FinishedState(this._sprint));
    }

    public override string ToString()
    {
        return "StartedState";
    }

    public void UploadDocument(string documentName, string documentContent)
    {
        throw new NotImplementedException();
    }
}

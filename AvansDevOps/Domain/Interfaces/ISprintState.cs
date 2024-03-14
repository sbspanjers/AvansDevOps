namespace AvansDevOps.Domain.Interfaces;

public interface ISprintState
{
    void NextPhase();

    void EditSprintMetaData();

    void GotToFinishedState();

    void FinishSprint();
}

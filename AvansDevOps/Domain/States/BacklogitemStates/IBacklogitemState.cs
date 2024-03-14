namespace AvansDevOps.Domain.States.BacklogitemStates;

public interface IBacklogitemState
{
    void NextPhase();

    void GoToToDo();

    void GoToREadyForTesting();

    void EditMetaDataBacklogitem();
}

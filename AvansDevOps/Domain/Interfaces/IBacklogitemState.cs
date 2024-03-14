namespace AvansDevOps.Domain.Interfaces;

public interface IBacklogitemState
{
    void NextPhase();

    void GoToToDo();

    void GoToREadyForTesting();

    void EditMetaDataBacklogitem();
}

using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Observer;

namespace AvansDevOps.Domain.States.BacklogitemStates;

public class ToDoState : IBacklogitemState
{

    private BacklogItem _backlogItem;

    public ToDoState(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;
    }
    public void EditMetaDataBacklogitem()
    {
        throw new NotImplementedException();
    }

    public void GoToREadyForTesting()
    {
        throw new NotImplementedException();
    }

    public void GoToToDo()
    {
        throw new NotImplementedException();
    }

    public void NextPhase()
    {
        throw new NotImplementedException();
    }
}

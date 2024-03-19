using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.States.BacklogitemStates;

public class DoingState : IBacklogitemState
{
    private BacklogItem _backlogitem;

    public DoingState(BacklogItem backlogitem)
    {
        this._backlogitem = backlogitem;
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
        _backlogitem.SetState(new ReadyForTestingState(_backlogitem));
    }
}

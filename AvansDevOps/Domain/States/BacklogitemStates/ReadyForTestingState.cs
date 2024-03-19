using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.States.BacklogitemStates;

public class ReadyForTestingState : IBacklogitemState
{
    private BacklogItem _backlogitem;

    public ReadyForTestingState(BacklogItem backlogitem)
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
        _backlogitem.SetState(new TestedState(_backlogitem));
    }
}

using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Rules.NotifyRule;

namespace AvansDevOps.Domain.States.BacklogitemStates;

public class DoingState : IBacklogitemState
{
    private BacklogItem _backlogitem;

    public DoingState(BacklogItem backlogitem)
    {
        this._backlogitem = backlogitem;
        this._backlogitem.Sprint.NotifySubscribers(_backlogitem.getName() + " has been moved to doing", new GeneralRule());
    }
    
    public void EditMetaDataBacklogitem()
    {
        throw new NotImplementedException();
    }

    public void GoToReadyForTesting()
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

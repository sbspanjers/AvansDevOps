using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Rules.NotifyRule;

namespace AvansDevOps.Domain.States.BacklogitemStates;

public class ReadyForTestingState : IBacklogitemState
{
    private BacklogItem _backlogitem;

    public ReadyForTestingState(BacklogItem backlogitem)
    {
        this._backlogitem = backlogitem;
        this._backlogitem.Sprint.NotifySubscribers(_backlogitem.getName() + " has been moved to Ready for testing", new TesterRule());

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
        _backlogitem.SetState(new TestedState(_backlogitem));
    }
}

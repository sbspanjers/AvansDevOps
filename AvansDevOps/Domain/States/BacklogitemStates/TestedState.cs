using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Rules.NotifyRule;

namespace AvansDevOps.Domain.States.BacklogitemStates;

public class TestedState : IBacklogitemState
{

    private BacklogItem _backlogitem;

    public TestedState(BacklogItem backlogitem)
    {
        _backlogitem = backlogitem;
        this._backlogitem.Sprint.NotifySubscribers(_backlogitem.getName() + " has been moved to Tested", new GeneralRule());

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
        _backlogitem.Sprint.NotifySubscribers(_backlogitem.getName() + " has been moved to ToDo", new ScrummasterRule());
        _backlogitem.SetState(new ToDoState(_backlogitem));
    }

    public void NextPhase()
    {
        _backlogitem.SetState(new DoneState(_backlogitem)); 
    }
}

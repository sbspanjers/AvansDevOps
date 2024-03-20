using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Rules.NotifyRule;

namespace AvansDevOps.Domain.States.BacklogitemStates;

public class DoneState : IBacklogitemState
{
    private BacklogItem _backlogItem;

    public DoneState(BacklogItem backlogitem)
    {
        this._backlogItem = backlogitem;
        this._backlogItem.Sprint.NotifySubscribers(_backlogItem.getName() + " has been moved to Done", new GeneralRule());
    }


    public void EditMetaDataBacklogitem()
    {
        throw new NotImplementedException();
    }

    public void GoToReadyForTesting()
    {
        _backlogItem.SetState(new ReadyForTestingState(_backlogItem));
    }

    public void GoToToDo()
    {
        _backlogItem.SetState(new ToDoState(_backlogItem));
    }

    public void NextPhase()
    {
        Console.WriteLine("Backlogitem is already done");
    }
}

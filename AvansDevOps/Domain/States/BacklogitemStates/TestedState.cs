using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.States.BacklogitemStates;

public class TestedState : IBacklogitemState
{

    private BacklogItem _backlogitem;

    public TestedState(BacklogItem backlogitem)
    {
        _backlogitem = backlogitem;
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
        _backlogitem.SetState(new DoneState(_backlogitem)); 
    }
}

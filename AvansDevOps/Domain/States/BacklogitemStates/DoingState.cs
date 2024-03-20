using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Rules.NotifyRule;

namespace AvansDevOps.Domain.States.BacklogitemStates;

public class DoingState : IBacklogitemState
{
    private BacklogItem _backlogItem;

    public DoingState(BacklogItem backlogitem)
    {
        this._backlogItem = backlogitem;
        this._backlogItem.Sprint.NotifySubscribers(_backlogItem.getName() + " has been moved to doing", new GeneralRule());
    }

    public void AddCommentToBacklogItemReviewThread(string text, User user)
    {
        _backlogItem.ReviewThread.Comments.Add(Comment.CreateComment(text, user));
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
        _backlogItem.SetState(new ToDoState(_backlogItem));
    }

    public void NextPhase()
    {
        _backlogItem.SetState(new ReadyForTestingState(_backlogItem));
    }
}

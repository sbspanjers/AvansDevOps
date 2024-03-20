using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Rules.NotifyRule;

namespace AvansDevOps.Domain.States.BacklogitemStates;

public class ReadyForTestingState : IBacklogitemState
{
    private BacklogItem _backlogItem;

    public ReadyForTestingState(BacklogItem backlogItem)
    {
        this._backlogItem = backlogItem;
        this._backlogItem.Sprint.NotifySubscribers(_backlogItem.getName() + " has been moved to Ready for testing", new TesterRule());

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
        throw new NotImplementedException();
    }

    public void NextPhase()
    {
        _backlogItem.SetState(new TestedState(_backlogItem));
    }
}

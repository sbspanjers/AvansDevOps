using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.States.BacklogitemStates;

public class ToDoState : IBacklogitemState
{

    private BacklogItem _backlogItem;

    public ToDoState(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;

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
        _backlogItem.SetState(new DoingState(_backlogItem));
    }
}

using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.States.BacklogitemStates;
using AvansDevOps.Domain.Users;

namespace DevOpsTests.Domain.States.BacklogitemStates;

public class ReadyForTestingStateTest
{

    [Fact]
    public void TestAddCommentToBacklogItemReviewThread()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        BacklogItem backlogItem = new BacklogItem("BTest", "DTest", project);
        Sprint sprint = new ReviewSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        backlogItem.SetSprint(sprint);
        backlogItem.SetState(new ReadyForTestingState(backlogItem));
        backlogItem.ReviewThread = new ReviewThread();
        User user = new Scrummaster();

        // Act
        backlogItem.State.AddCommentToBacklogItemReviewThread("test", user);

        // Assert
        Assert.Single(backlogItem.ReviewThread.Comments);
    }

    [Fact]
    public void TestNextPhase()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        BacklogItem backlogItem = new BacklogItem("BTest", "DTest", project);
        Sprint sprint = new ReviewSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        backlogItem.SetSprint(sprint);
        backlogItem.SetState(new ReadyForTestingState(backlogItem));

        // Act
        backlogItem.NextState();

        // Assert
        Assert.IsType<TestedState>(backlogItem.State);
    }

    [Fact]
    public void TestGoToToDo()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        BacklogItem backlogItem = new BacklogItem("BTest", "DTest", project);
        Sprint sprint = new ReviewSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        backlogItem.SetSprint(sprint);
        backlogItem.SetState(new ReadyForTestingState(backlogItem));

        // Act & Assert
        Assert.Throws<NotImplementedException>(() => backlogItem.State.GoToToDo());
    }

    [Fact]
    public void TestEditMetaDataBacklogitem()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        BacklogItem backlogItem = new BacklogItem("BTest", "DTest", project);
        Sprint sprint = new ReviewSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        backlogItem.SetSprint(sprint);
        backlogItem.SetState(new ReadyForTestingState(backlogItem));

        // Act & Assert
        Assert.Throws<NotImplementedException>(() => backlogItem.State.EditMetaDataBacklogitem());
    }

    [Fact]
    public void TestGoToReadyForTesting()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        BacklogItem backlogItem = new BacklogItem("BTest", "DTest", project);
        Sprint sprint = new ReviewSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        backlogItem.SetSprint(sprint);
        backlogItem.SetState(new ReadyForTestingState(backlogItem));

        // Act & Assert
        Assert.Throws<NotImplementedException>(() => backlogItem.State.GoToReadyForTesting());
    }
}

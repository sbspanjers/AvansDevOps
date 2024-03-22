using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.States.BacklogitemStates;
using AvansDevOps.Domain.Users;

namespace DevOpsTests.Domain.States.BacklogitemStates;

public class DoneStateTest
{
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
        backlogItem.SetState(new DoneState(backlogItem));

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            backlogItem.State.NextPhase();

            // Assert
            string expectedOutput = $"Backlogitem is already done";

            Assert.Contains(expectedOutput, sw.ToString());
        }
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
        backlogItem.SetState(new DoneState(backlogItem));

        // Act
        backlogItem.State.GoToToDo();

        // Assert
        Assert.IsType<ToDoState>(backlogItem.State);
    }

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
        backlogItem.SetState(new DoneState(backlogItem));
        User user = new Scrummaster();

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            backlogItem.State.AddCommentToBacklogItemReviewThread("string", user);

            // Assert
            string expectedOutput = $"Comment not possible in Done state.";
            

            Assert.Contains(expectedOutput, sw.ToString());
        }
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
        backlogItem.SetState(new DoneState(backlogItem));

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
        backlogItem.SetState(new DoneState(backlogItem));

        // Act
        backlogItem.State.GoToReadyForTesting();

        // Assert
        Assert.IsType<ReadyForTestingState>(backlogItem.State);
    }
}

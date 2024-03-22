using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Observer.Subscribers;
using AvansDevOps.Domain.States.SprintStates;
using AvansDevOps.Domain.Users;

namespace DevOpsTests.Domain.Users;

public class ScrummasterTest
{
    [Fact]
    public void Test_AssignUserToProject()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        User user = new Scrummaster();

        // Act
        user.AssignUserToProject(project, user);

        // Assert
        Assert.Contains(project, user.Projects);
    }

    [Fact]
    public void Test_UploadDocumentToFinishReviewSpint()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("testProject", pipeline, git);
        project.CreateSprint("testSprint", DateTime.Now, DateTime.Now.AddDays(14), new ReviewSprintFactory());
        User user = new Scrummaster();
        Sprint sprint = project.GetSprint("testSprint");
        sprint.SetSprintState(new FinishedState(sprint));

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            user.UploadDocumentToFinishReviewSpint(project, "testSprint", "test", "test");

            // Assert
            string expectedOutput = "test uploaded.";

            Assert.Contains(expectedOutput, sw.ToString());
            Assert.True(sprint.GetState() is ClosedState);
        }
    }

    [Fact]
    public void Test_CancelPipeline()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        Scrummaster user = new Scrummaster();

        // Act
        user.CancelPipeline(project, "test");

        // Assert
        Assert.True(true);
    }

    [Fact]
    public void Test_StartPipeline()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        Scrummaster user = new Scrummaster();

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            user.StartPipeline(project, "test", true);

            // Assert
            string expectedOutput = $"DEVOPS_SYSTEM: Deploy";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void TestFail_StartPipeline()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        Scrummaster user = new Scrummaster();
        Sprint sprint = project.CreateSprint("test", DateTime.Now, DateTime.Now.AddDays(14), new DeploymentSprintFactory());
        sprint.AddUserToSprint(user);
        sprint.SetSprintState(new FinishedState(sprint));
        sprint.AddSubscriber(new WhatsappSubscriber());

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            user.StartPipeline(project, "test", false);

            // Assert
            string expectedOutput = $"The pipeline has failed";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }
}

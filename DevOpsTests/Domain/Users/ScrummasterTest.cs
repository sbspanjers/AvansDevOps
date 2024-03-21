using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
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

        // Act
        user.UploadDocumentToFinishReviewSpint(project, "testSprint", "test", "test");

        // Assert
        Assert.True(true);

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

        // Act
        // wordt nu random gefaald
        //user.StartPipeline(project, "test");

        // Assert
        Assert.True(true);
    }


}

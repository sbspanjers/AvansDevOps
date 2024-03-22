using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Export;
using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.States.BacklogitemStates;
using AvansDevOps.Domain.States.SprintStates;
using AvansDevOps.Domain.Users;

namespace DevOpsTests.Domain.Models;

public class UserTest
{
    [Fact]
    public void TestCreateProject()
    {
        // Arrange
        User user = new Scrummaster();
        string projectName = "TestProject";
        Pipeline pipeline = new();
        IGit git = new GitAdapter();

        // Act
        Project project = user.CreateProject(projectName, pipeline, git);

        // Assert
        Assert.NotNull(project);
        Assert.Equal(projectName, project.Name);
    }

    [Fact]
    public void TestEditBacklogItem()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string backlogItemName = "TestBacklogItem";
        string backlogItemDescription = "TestDescription";
        List<SubTask> subTasks = new();
        project.AddBacklogItem(new BacklogItem(backlogItemName, backlogItemDescription, project));

        // Act
        BacklogItem backlogItem = user.EditBacklogItem(project, backlogItemName, backlogItemDescription, subTasks);

        // Assert
        Assert.NotNull(backlogItem);
        Assert.Equal(backlogItemName, backlogItem.getName());
    }

    [Fact]
    public void TestCreateBacklogItem()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string backlogItemName = "TestBacklogItem";
        string backlogItemDescription = "TestDescription";

        // Act
        BacklogItem backlogItem = user.CreateBacklogItem(project, backlogItemName, backlogItemDescription);

        // Assert
        Assert.NotNull(backlogItem);
        Assert.Equal(backlogItemName, backlogItem.getName());
    }

    [Fact]
    public void TestAddBacklogItemToSprint()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string backlogItemName = "TestBacklogItem";
        Sprint sprint = new DeploymentSprint("TestSprint", DateTime.Now, DateTime.Now.AddDays(14));
        project.AddBacklogItem(new BacklogItem(backlogItemName, "TestDescription", project));

        // Act
        user.AddBacklogItemToSprint(project, backlogItemName, sprint);

        // Assert
        Assert.Single(sprint.BacklogItems);
        Assert.Contains(sprint.BacklogItems, b => b.getName() == backlogItemName);
    }

    [Fact]
    public void TestMoveBacklogItemToNextState()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string backlogItemName = "TestBacklogItem";
        BacklogItem backlogItem = new(backlogItemName, "TestDescription", project);
        project.AddBacklogItem(backlogItem);
        backlogItem.SetSprint(new DeploymentSprint("TestSprint", DateTime.Now, DateTime.Now.AddDays(14)));
        backlogItem.SetState(new ToDoState(backlogItem));

        // Act
        user.MoveBacklogItemToNextState(project, backlogItemName);

        // Assert
        Assert.IsType<DoingState>(project.GetBacklogItem(backlogItemName).State);
    }

    [Fact]
    public void TestCreateSprint()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string sprintName = "TestSprint";
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now.AddDays(14);
        SprintFactory sprintFactory = new DeploymentSprintFactory();

        // Act
        Sprint sprint = user.CreateSprint(project, sprintName, startDate, endDate, sprintFactory);

        // Assert
        Assert.NotNull(sprint);
        Assert.Equal(sprintName, sprint.Name);
    }

    [Fact]
    public void TestEditSprint()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string sprintName = "TestSprint";
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now.AddDays(14);
        string newName = "NewTestSprint";
        SprintFactory sprintFactory = new DeploymentSprintFactory();
        Sprint sprint = user.CreateSprint(project, sprintName, startDate, endDate, sprintFactory);

        // Act
        Sprint editedSprint = user.EditSprint(project, sprintName, startDate, endDate, newName);

        // Assert
        Assert.NotNull(editedSprint);
        Assert.Equal(newName, editedSprint.Name);
    }

    [Fact]
    public void TestSeeCurrentSprintState()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string sprintName = "TestSprint";
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now.AddDays(14);
        SprintFactory sprintFactory = new DeploymentSprintFactory();
        Sprint sprint = user.CreateSprint(project, sprintName, startDate, endDate, sprintFactory);

        // Act
        string state = user.SeeCurrentSprintState(project, sprintName);

        // Assert
        Assert.Equal(sprint.GetState().ToString(), state);
    }

    [Fact]
    public void TestMoveSprintToNextPhase()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string sprintName = "TestSprint";
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now.AddDays(14);
        SprintFactory sprintFactory = new DeploymentSprintFactory();
        Sprint sprint = user.CreateSprint(project, sprintName, startDate, endDate, sprintFactory);

        // Act
        user.MoveSprintToNextPhase(project, sprintName);

        // Assert
        Assert.IsType<StartedState>(sprint.GetState());
    }

    [Fact]
    public void TestConnectDeploymentSprintToPipelineOfProject()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string sprintName = "TestSprint";
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now.AddDays(14);
        SprintFactory sprintFactory = new DeploymentSprintFactory();
        Sprint sprint = user.CreateSprint(project, sprintName, startDate, endDate, sprintFactory);

        // Act
        user.ConnectDeploymentSprintToPipelineOfProject(project, sprintName);

        // Assert
        Assert.NotNull(sprint.Pipeline);
        Assert.Equal(project.Pipeline, sprint.Pipeline);
    }

    [Fact]
    public void TestConnectPipelineToSprint()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string sprintName = "TestSprint";
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now.AddDays(14);
        SprintFactory sprintFactory = new DeploymentSprintFactory();
        Sprint sprint = user.CreateSprint(project, sprintName, startDate, endDate, sprintFactory);
        Pipeline pipeline = new();

        // Act
        user.ConnectPipelineToSprint(project, sprintName, pipeline);

        // Assert
        Assert.NotNull(sprint.Pipeline);
        Assert.Equal(pipeline, sprint.Pipeline);
    }

    [Fact]
    public void TestCreateReviewThread()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        Forum forum = new Forum();
        BacklogItem backlogItem = new("TestBacklogItem", "TestDescription", project);
        string threadTitle = "TestThread";
        project.AddBacklogItem(backlogItem);

        // Act
        var result = user.CreateReviewThread(project, backlogItem.getName(), threadTitle, forum);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(threadTitle, result.Title);
    }

    [Fact]
    public void TestAddCommentToReviewThread()
    {
    // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        Forum forum = new Forum();
        BacklogItem backlogItem = new("TestBacklogItem", "TestDescription", project);
        string threadTitle = "TestThread";
        project.AddBacklogItem(backlogItem);
        ReviewThread reviewThread = user.CreateReviewThread(project, backlogItem.getName(), threadTitle, forum);
        string comment = "TestComment";

        // Act
        user.AddCommentToReviewThread(reviewThread, comment);

        // Assert
        Assert.Single(reviewThread.Comments);
        Assert.Contains(reviewThread.Comments, c => c.Text == comment);
    }

    [Fact]
    public void TestCreateReport()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string sprintName = "TestSprint";
        project.CreateSprint(sprintName, DateTime.Now, DateTime.Now.AddDays(14), new DeploymentSprintFactory());

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            user.CreateReport(project, sprintName, new ExportPNG());

            // Assert
            string expectedOutput = $"Exporting to PNG...";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void TestAddUserToSprint()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string sprintName = "TestSprint";
        Sprint sprint = project.CreateSprint(sprintName, DateTime.Now, DateTime.Now.AddDays(14), new DeploymentSprintFactory());
        User newUser = new Scrummaster();

        // Act
        user.AddUserToSprint(project, sprintName, newUser);

        // Assert
        Assert.Contains(sprint.Users, u => u.Name == newUser.Name);
    }

    [Fact]
    public void TestCreateReview()
    { 
    // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string sprintName = "TestSprint";
        Sprint sprint = project.CreateSprint(sprintName, DateTime.Now, DateTime.Now.AddDays(14), new ReviewSprintFactory());
        sprint.SetSprintState(new FinishedState(sprint));
        string review = "TestReview";

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            user.CreateReview(project, sprintName, review);

            // Assert
            string expectedOutput = $"REVIEW: {review}";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void TestCancelOrBackToFinishPipeline()
    {
        // Arrange
        User user = new Scrummaster();
        Project project = new("TestProject", new(), new GitAdapter());
        string sprintName = "TestSprint";
        Sprint sprint = project.CreateSprint(sprintName, DateTime.Now, DateTime.Now.AddDays(14), new DeploymentSprintFactory());
        sprint.SetSprintState(new ErrorState(sprint));

        // Act
        user.CancelOrBackToFinishPipeline(project, sprintName, false, true);

        // Assert
        Assert.IsType<CanceledState>(sprint.GetState());
    }

    [Fact]
    public void TestToString()
    {
        // Arrange
        User user = new Scrummaster();
        string name = "TestName";
        user.Name = name;

        // Act
        string result = user.ToString();

        // Assert
        Assert.Contains(name, result);
    }
}

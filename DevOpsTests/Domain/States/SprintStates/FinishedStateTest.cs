using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.States.SprintStates;

namespace DevOpsTests.Domain.States.SprintStates;

public class FinishedStateTest
{
    [Fact]
    public void Test_CreateReview()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new FinishedState(sprint));

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            string comment = "Test";
            sprint.GetState().CreateReview(comment);

            // Assert
            string expectedOutput = $"REVIEW: {comment}";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void Test_EditSprintMetaData()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new FinishedState(sprint));

        // Act
        string newName = "NewName";
        sprint.GetState().EditSprintMetaData(newName, DateTime.Now, DateTime.Now.AddDays(14));

        // Assert
        Assert.Equal(newName, sprint.Name);
    }

    [Fact]
    public void Test_FinishSprint()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new FinishedState(sprint));

        // Act & Assert
        Assert.Throws<NotImplementedException>(() => sprint.GetState().FinishSprint(true));
    }

    [Fact]
    public void Test_GotToAfterFinishedState()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new FinishedState(sprint));

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            sprint.GetState().GotToAfterFinishedState(true);

            // Assert
            string expectedOutput = "Sprint already in finished state.";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void Test_NextPhase()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new FinishedState(sprint));
        sprint.Pipeline = pipeline;

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            sprint.GetState().NextPhase();

            // Assert
            string expectedOutput = $"DEVOPS_SYSTEM: Deploy";

            Assert.Contains(expectedOutput, sw.ToString());
            Assert.IsType<ClosedState>(sprint.GetState());
        }

    }

    [Fact]
    public void Test_ToString()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new FinishedState(sprint));

        // Act
        string result = sprint.GetState().ToString();

        // Assert
        Assert.Equal("FinishedState", result);
    }

    [Fact]
    public void Test_UploadDocument()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new FinishedState(sprint));

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            string documentName = "Test";
            sprint.GetState().UploadDocument(documentName, "test");

            // Assert
            string expectedOutput = $"{documentName} uploaded.";

            Assert.Contains(expectedOutput, sw.ToString());
            Assert.IsType<ClosedState>(sprint.GetState());
        }
    }
}

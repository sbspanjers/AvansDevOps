using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.States.SprintStates;

namespace DevOpsTests.Domain.States.SprintStates;

public class ErrorStateTest
{
    [Fact]
    public void Test_CreateReview()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new ErrorState(sprint));

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            sprint.GetState().CreateReview("Test");

            // Assert
            string expectedOutput = "Review not possible.";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void Test_EditSprintMetaData()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new ErrorState(sprint));

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
        sprint.SetSprintState(new ErrorState(sprint));

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            sprint.GetState().FinishSprint(true);

            // Assert
            string expectedOutput = "Finish sprint not possible.";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void Test_GotToAfterFinishedState()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new ErrorState(sprint));
        sprint.Pipeline = pipeline;

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            sprint.GetState().GotToAfterFinishedState(true);

            // Assert
            string expectedOutput = "Releasing again";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void Test_NextPhase()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new ErrorState(sprint));

        // Act
        sprint.GetState().NextPhase();

        // Assert
        Assert.IsType<CanceledState>(sprint.GetState());

    }

    [Fact]
    public void Test_ToString()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new ErrorState(sprint));

        // Act
        string result = sprint.GetState().ToString();

        // Assert
        Assert.Equal("ErrorState", result);
    }

    [Fact]
    public void Test_UploadDocument()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("STest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new ErrorState(sprint));

        // Act & Assert
        Assert.Throws<NotImplementedException>(() => sprint.GetState().UploadDocument("test", "test"));
    }
}

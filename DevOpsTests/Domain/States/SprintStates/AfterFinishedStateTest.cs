using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.States.SprintStates;

namespace DevOpsTests.Domain.States.SprintStates;

public class AfterFinishedStateTest
{
    [Fact]
    public void Test_FinishSprint()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        Sprint sprint = new DeploymentSprint("Stest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.Pipeline = pipeline;
        sprint.SetSprintState(new AfterFinishedState(sprint));

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            bool deploySuccess = true;
            sprint.GetState().FinishSprint(deploySuccess);

            // Assert
            string expectedOutput = "DEVOPS_SYSTEM: Deploy";

            Assert.Contains(expectedOutput, sw.ToString());
            Assert.IsType<ClosedState>(sprint.GetState());
        }
    }

    [Fact]
    public void TestFailed_FinishSprint()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        Sprint sprint = new DeploymentSprint("Stest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.Pipeline = pipeline;
        sprint.SetSprintState(new AfterFinishedState(sprint));

        // Act
        bool deploySuccess = false;
        sprint.GetState().FinishSprint(deploySuccess);

        // Assert
        Assert.IsType<ErrorState>(sprint.GetState());
    }

    [Fact]
    public void Test_EditSprintMetaData()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("Stest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new AfterFinishedState(sprint));

        // Act
        string newName = "NewName";
        sprint.GetState().EditSprintMetaData(newName, DateTime.Now, DateTime.Now.AddDays(14));

        // Assert
        Assert.Equal(sprint.Name, newName);
    }

    [Fact]
    public void Test_GotToAfterFinishedState()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("Stest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new AfterFinishedState(sprint));

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            sprint.GetState().GotToAfterFinishedState(true);

            // Assert
            string expectedOutput = "Sprint is already finished.";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void Test_NextPhase()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("Stest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new AfterFinishedState(sprint));

        // Act
        sprint.GetState().NextPhase();

        // Assert
        Assert.IsType<ClosedState>(sprint.GetState());
    }

    [Fact]
    public void Test_ToString()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("Stest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new AfterFinishedState(sprint));

        // Act
        string result = sprint.GetState().ToString();

        // Assert
        Assert.Equal("AfterFinishedState", result);
    }

    [Fact]
    public void Test_CreateReview()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("Stest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new AfterFinishedState(sprint));

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            sprint.GetState().CreateReview("test");

            // Assert
            string expectedOutput = "Review not possible.";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void Test_UploadDocument()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("Stest", DateTime.Now, DateTime.Now.AddDays(14));
        sprint.SetSprintState(new AfterFinishedState(sprint));

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            sprint.GetState().UploadDocument("test", "test");

            // Assert
            string expectedOutput = "Upload not possible.";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }
}

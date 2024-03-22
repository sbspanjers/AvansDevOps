using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevOpsTests.Domain.Factory;

public class DeploymentSprintTest
{

    [Fact]
    public void TestCreateFinishSprintReturnsTrueDeploymentSprint()
    {
        // Arrange
        DeploymentSprint sprint = new DeploymentSprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
        var pipelineMock = new Mock<Pipeline>();
        pipelineMock.Setup(x => x.Start(It.IsAny<Sprint>(), true)).Returns(true);
        sprint.Pipeline = pipelineMock.Object;
                
        // Act
        var result = sprint.FinishSprint(true);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void TestCreateFinishSprintReturnsFalseDeploymentSprint()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
        var pipelineMock = new Mock<Pipeline>();
        pipelineMock.Setup(x => x.Start(It.IsAny<Sprint>(), true)).Returns(false);
        sprint.Pipeline = pipelineMock.Object;

        // Act
        var result = sprint.FinishSprint(true);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CreateReviewTestDeploymentSprint()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
        using StringWriter sw = new();
        Console.SetOut(sw);
        // Act
        sprint.CreateReview("Review");

        // Assert
        string expectedOutput = "Review not possible on a Deployment sprint.";
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void TestToStringDeploymentSprint()
    {
        // Arrange
        Sprint sprint = new DeploymentSprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
        // Act
        string result = sprint.ToString();
        // Assert
        Assert.Contains("Deployment", result);
    }

}

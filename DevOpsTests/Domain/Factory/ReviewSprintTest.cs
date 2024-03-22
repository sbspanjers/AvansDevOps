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

public class ReviewSprintTest
{
    [Fact]
    public void CreateReviewTestReviewSprint()
    {
        // Arrange
        Sprint sprint = new ReviewSprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
        using StringWriter sw = new();
        Console.SetOut(sw);
        // Act
        sprint.CreateReview("Review");

        // Assert
        string expectedOutput = "Review";
        Assert.Contains(expectedOutput, sw.ToString());
    }

    [Fact]
    public void TestCreateFinishSprintReturnsTrueReviewSprint()
    {
        // Arrange
        Sprint sprint = new ReviewSprint("Sprint", DateTime.Now, DateTime.Now.AddDays(14));
        var pipelineMock = new Mock<Pipeline>();
        pipelineMock.Setup(x => x.Start(It.IsAny<Sprint>(), true)).Returns(true);
        sprint.Pipeline = pipelineMock.Object;
                
        // Act
        var result = sprint.FinishSprint(true);

        // Assert
        Assert.True(result);
    }
}

using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Factory;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsTests.Domain.Factory;

public class DeploymentFactoryTest
{

    [Fact]
    public void TestCreateDeploymentSprint()
    {
        // Arrange
        var sprintFactory = new DeploymentSprintFactory();
        var project = new Project("Test", new Pipeline(), new GitAdapter());
        var sprint = project.CreateSprint("Test", DateTime.Now, DateTime.Now, sprintFactory);

        // Act
        var result = project.GetSprint("Test");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(sprint, result);
        Assert.IsType<DeploymentSprint>(result);
    }
}

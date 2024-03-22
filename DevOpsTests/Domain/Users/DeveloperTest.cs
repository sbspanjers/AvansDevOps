﻿using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Users;

namespace DevOpsTests.Domain.Users;

public class DeveloperTest
{

    [Fact]
public void Test_AssignUserToProject()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        User user = new Developer();

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
        Project project = new Project("test", pipeline, git);
        User user = new Developer();

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            user.UploadDocumentToFinishReviewSpint(project, "test", "test", "test");

            // Assert
            string expectedOutput = $"{user.Name} doesn't have permissions for this action.";

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }
}

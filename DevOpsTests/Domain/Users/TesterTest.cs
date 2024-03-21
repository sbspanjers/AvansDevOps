using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Users;

namespace DevOpsTests.Domain.Users;

public class TesterTest
{

    [Fact]
    public void Test_AssignUserToProject()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        User user = new Tester();

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
        User user = new Tester();

        // Act
        user.UploadDocumentToFinishReviewSpint(project, "test", "test", "test");

        // Assert
        Assert.True(true);

        //hier valt weinig te testen, aangezien de methode alleen een console.writeline aanroept
    }
}

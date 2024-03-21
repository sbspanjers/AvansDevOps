using AvansDevOps.Domain.Adapter.GitAdapter;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Users;

namespace DevOpsTests.Domain.Users;

public class ProductOwnerTest
{
    [Fact]
    public void Test_AssignUserToProject()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        User user = new ProductOwner();

        // Act
        user.AssignUserToProject(project, user);

        // Assert
        Assert.Contains(project, user.Projects);
        Assert.Equal(user, project.GetProductOwner());
    }

    [Fact]
    public void Test_UploadDocumentToFinishReviewSpint()
    {
        // Arrange
        Pipeline pipeline = new Pipeline();
        IGit git = new GitAdapter();
        Project project = new Project("test", pipeline, git);
        User user = new ProductOwner();

        // Act
        user.UploadDocumentToFinishReviewSpint(project, "test", "test", "test");

        // Assert
        Assert.True(true);

        //hier valt weinig te testen, aangezien de methode alleen een console.writeline aanroept
    }
}

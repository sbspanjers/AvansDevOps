using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.Users;

public class Tester : User
{
    public override void AssignUserToProject(Project project, User user)
    {
        if (!user.Projects.Contains(project))
        {
            user.Projects.Add(project);
        }
    }

    public override void UploadDocumentToFinishReviewSpint(Project project, string sprintName, string documentName, string documentContent)
    {
        Console.WriteLine(this.Name + " doesn't have permissions for this action.");
    }
}

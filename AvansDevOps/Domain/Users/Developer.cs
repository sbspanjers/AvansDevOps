using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.Users;

public class Developer : User
{
    public override void UploadDocumentToFinishReviewSpint(Project project, string sprintName, string documentName, string documentContent)
    {
        Console.WriteLine(this.Name + " doesn't have permissions for this action.");
    }
}

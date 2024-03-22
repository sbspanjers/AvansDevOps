using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.Users;

public class Scrummaster : User
{
    public override void AssignUserToProject(Project project, User user)
    {
        if (!user.Projects.Contains(project))
        {
            user.Projects.Add(project);
        }
    }

    public void CancelPipeline(Project project, string sprintName)
    {
        project.Pipeline.Cancel(project.GetSprint(sprintName));
    }

    public void StartPipeline(Project project, string sprintName, bool deploySuccess)
    {
        project.Pipeline.Start(project.GetSprint(sprintName), deploySuccess);
    }

    public override void UploadDocumentToFinishReviewSpint(Project project, string sprintName, string documentName, string documentContent)
    {
        Sprint sprint = project.GetSprint(sprintName);
        sprint.GetState().UploadDocument(documentName, documentContent);
    }
}

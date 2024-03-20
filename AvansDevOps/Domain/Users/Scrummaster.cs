using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.Users;

public class Scrummaster : User
{
    public void CancelPipeline(Project project, string sprintName)
    {
        project.Pipeline.Cancel(project.GetSprint(sprintName));
    }

    public void StartPipeline(Project project, string sprintName)
    {
        project.Pipeline.Start(project.GetSprint(sprintName));
    }

    public override void UploadDocumentToFinishReviewSpint(Project project, string sprintName, string documentName, string documentContent)
    {
        Sprint sprint = project.GetSprint(sprintName);
        sprint.GetState().UploadDocument(documentName, documentContent);
    }
}

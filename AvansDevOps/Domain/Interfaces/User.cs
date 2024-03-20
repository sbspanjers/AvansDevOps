using AvansDevOps.Domain.Models;
using AvansDevOps.Domain.Users;

namespace AvansDevOps.Domain.Interfaces;

public abstract class User
{
    public string Name { get; set; } = string.Empty;
    private string _email;
    private List<Project> _projects;

    public Project CreateProject(string name, Pipeline pipeline, IGit git)
    {
        Project newProject = new(name, pipeline, git);
        return newProject;
    }

    public BacklogItem EditBacklogItem(Project project, string name, string description, List<SubTask> subTasks)
    {
        project.EditBacklogItem(name, description, subTasks);
        return project.GetBacklogItem(name);
    }

    public BacklogItem CreateBacklogItem(Project project, string name, string description)
    {
        return project.AddBacklogItem(new BacklogItem(name, description, project));
    }

    public void AddBacklogItemToSprint(Project project, string backlogItemName, Sprint sprint)
    {
        BacklogItem backlogItem = project.GetBacklogItem(backlogItemName);
        backlogItem.SetSprint(sprint);
        sprint.AddBacklogItem(backlogItem);
    }

    public void MoveBacklogItemToNextState(Project project, string backlogItemName)
    {
        BacklogItem backlogItem = project.GetBacklogItem(backlogItemName);
        backlogItem.NextState();
    }

    public Sprint CreateSprint(Project project, string sprintName, DateTime startDate, DateTime endDate, SprintFactory sprintFactory)
    {

        Sprint createdSprint =  project.CreateSprint(sprintName, startDate, endDate, sprintFactory);
        createdSprint.Users.Add( new Scrummaster() { Name = "Stijn" }); //Moet nog gefixt worden

        return project.GetSprint(sprintName);
    }

    public Sprint EditSprint(Project project, string sprintName, DateTime startDate, DateTime endDate, string newName)
    {
        return project.GetSprint(sprintName).EditSprint(newName, startDate, endDate);
    }

    public string SeeCurrentSprintState(Project project, string sprintName)
    {
        return project.GetSprint(sprintName).GetState().ToString();
    }

    public void MoveSprintToNextPhase(Project project, string sprintName)
    {
        project.GetSprint(sprintName).NextPhase();
    }

    public void ConnectDeploymentSprintToPipelineOfProject(Project project, string sprintName)
    {
        project.GetSprint(sprintName).Pipeline = project.Pipeline;
    }

    public void ConnectPipelineToSprint(Project project, string sprintName, Pipeline pipeline)
    {
        project.GetSprint(sprintName).Pipeline = pipeline;
    }

    public ReviewThread CreateReviewThread(Project project, string backlogItemName, string threadTitle, Forum forum)
    {
        var backlogItem = project.GetBacklogItem(backlogItemName);
        
        ReviewThread reviewThread = new();
        reviewThread.Title = threadTitle;
        reviewThread.BacklogItem = backlogItem;

        forum.Threads.Add(reviewThread);
        backlogItem.ReviewThread = reviewThread;
        return reviewThread;
    }

    public Comment AddCommentToReviewThread(ReviewThread reviewThread, string text)
    {
        var comment = Comment.CreateComment(text, this);
        reviewThread.Comments.Add(comment);
        return comment;
    }

    public void CreateReport(Project project, string sprintName)
    {
        project.GetSprint(sprintName).GenerateReport();
    }

    public void AddUserToSprint(Project project, string sprintName, User user)
    {
        project.GetSprint(sprintName).AddUserToSprint(user);
    }

    public void CreateReview(Project project, string sprintName, string message)
    {
        project.GetSprint(sprintName).CreateReview(message); 
    }

    public void CancelOrBackToFinishPipeline(Project project, string sprintName, bool repeat)
    {
        if(repeat)
        {
            project.GetSprint(sprintName).GetState().GotToAfterFinishedState();
        }
        else
        {
            project.GetSprint(sprintName).NextPhase();
        }
    }

    public abstract void UploadDocumentToFinishReviewSpint(Project project, string sprintName, string documentName, string documentContent);
}

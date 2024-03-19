using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.Users;

public class Scrummaster : User
{
    public void CancelPipeline(Project project)
    {
        project.Pipeline.Cancel();
    }

    public void StartPipeline(Project project)
    {
        project.Pipeline.Start();
    }
}

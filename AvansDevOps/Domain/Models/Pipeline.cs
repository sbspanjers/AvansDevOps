using AvansDevOps.Domain.Adapter.DevOpsAdapter;
using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Rules.NotifyRule;

namespace AvansDevOps.Domain.Models;

public class Pipeline
{
    private IAvansDevOps devOps;

    public string Name { get; set; } = string.Empty;

    public Pipeline()
    {
        this.devOps = new DevOpsAdapter();
    }

    public void Start(Sprint sprint)
    {
        int random = new Random().Next(0, 2); 
        // can go well
        if(random == 1)
        {
            devOps.Deploy();
        }
        else
        {
            //FAILED - notify the team via the sprint
            sprint.NotifySubscribers("The pipeline has failed", new ScrummasterRule());
          
        }
        

    }

    public void Cancel(Sprint sprint)
    {
        // ...
    }
}

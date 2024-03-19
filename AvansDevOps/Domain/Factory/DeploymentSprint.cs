using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Factory;

public class DeploymentSprint : Sprint
{

    public DeploymentSprint(string name, DateTime startDate, DateTime endDate) : base(name, startDate, endDate)
    {
        
    }
    public override void FinishSprint()
    {
        Pipeline.Start(this);
    }

    public override void CreateReview(string message)
    {
        // Review not possible
    }
}
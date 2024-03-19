using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Factory;

public class DeploymentSprint : Sprint
{
    public override void FinishSprint()
    {
        Pipeline.Start();
    }

    public override void CreateReview(string message)
    {
        // Review not possible
    }
}
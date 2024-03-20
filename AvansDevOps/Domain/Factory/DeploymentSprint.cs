using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.Factory;

public class DeploymentSprint : Sprint
{

    public DeploymentSprint(string name, DateTime startDate, DateTime endDate) : base(name, startDate, endDate)
    {
    }
    public override bool FinishSprint()
    {
       return Pipeline.Start(this);
    }

    public override void CreateReview(string message)
    {
        // Review not possible
        Console.WriteLine("Review not possible on a Deployment sprint.");
    }
    public override string ToString()
    {
        return $"Sprint: {this.Name}\nStart date: {this.StartDate}\nEnd date: {this.EndDate}\nPipeline: {this.Pipeline.Name}\nState: {this._sprintState}\nBacklog items:\n{string.Join("\n", this.BacklogItems.Select(x => x.ToString()))}";

    }
}
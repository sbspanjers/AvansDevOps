using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Factory;

public class ReviewSprint : Sprint
{
    public ReviewSprint(string name, DateTime startDate, DateTime endDate) : base(name, startDate, endDate)
    {
        
    }

    public override bool FinishSprint(bool deploySuccess)
    {
        
        _sprintState.NextPhase();
        return true;
    }

    public override void CreateReview(string message)
    {
        _sprintState.CreateReview(message);
    }
}

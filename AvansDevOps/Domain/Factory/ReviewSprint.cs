using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Factory;

public class ReviewSprint : Sprint
{
    public override void FinishSprint()
    {
        Console.WriteLine("File uploaded for review sprint.");
        _sprintState.NextPhase();
    }

    public override void CreateReview(string message)
    {
        Console.WriteLine("Review created.");
    }
}

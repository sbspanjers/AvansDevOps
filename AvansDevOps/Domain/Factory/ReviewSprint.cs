using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Factory;

public class ReviewSprint : Sprint
{
    public ReviewSprint(string name, DateTime startDate, DateTime endDate) : base(name, startDate, endDate)
    {
        
    }

    public override bool FinishSprint()
    {
        Console.WriteLine("File uploaded for review sprint.");
        _sprintState.NextPhase();
        //TODO Kijk hier naar
        return true;
    }

    public override void CreateReview(string message)
    {
        Console.WriteLine($"REVIEW: {message}");
    }
}

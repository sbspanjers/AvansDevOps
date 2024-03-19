using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Factory;

public class ReviewSprintFactory : SprintFactory
{
    public Sprint CreateSprint(string name, DateTime startDate, DateTime endDate)
    {
        return new ReviewSprint();
    }
}

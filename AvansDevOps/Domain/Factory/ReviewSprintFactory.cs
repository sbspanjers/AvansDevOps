using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.Factory;

public class ReviewSprintFactory : SprintFactory
{
    public Sprint CreateSprint(string name, DateTime startDate, DateTime endDate)
    {
        return new ReviewSprint(name, startDate, endDate);
    }
}

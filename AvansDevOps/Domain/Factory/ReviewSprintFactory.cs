using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Factory;

public class ReviewSprintFactory : SprintFactory
{
    public Sprint CreateSprint(Sprint sprint)
    {
        return new ReviewSprint();
    }
}

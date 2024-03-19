using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Factory;

public class DeploymentSprintFactory : SprintFactory
{

    public Sprint CreateSprint(string name, DateTime startDate, DateTime endDate)
    {
        return new DeploymentSprint();
    }
}

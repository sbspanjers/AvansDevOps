using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Factory;

public class DeploymentSprintFactory : SprintFactory
{
    public Sprint CreateSprint(Sprint sprint)
    {
        return new DeploymentSprint();
    }
}

using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Models;

namespace AvansDevOps.Domain.Factory;

public class DeploymentSprintFactory : SprintFactory
{

    public Sprint CreateSprint(string name, DateTime startDate, DateTime endDate)
    {
        return new DeploymentSprint(name, startDate, endDate);
    }
}

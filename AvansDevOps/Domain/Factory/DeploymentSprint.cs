using AvansDevOps.Domain.Interfaces;
using System;


namespace AvansDevOps.Domain.Factory;

public class DeploymentSprint : Sprint
{
    public override void Deploy()
    {
        // Deploy function
    }

    public override void Upload()
    {
        throw new NotSupportedException();
    }
}

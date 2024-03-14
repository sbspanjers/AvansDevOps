using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Factory;

public class ReviewSprint : Sprint
{
    public override void Deploy()
    {
        throw new NotSupportedException();
    }

    public override void Upload()
    {
       // Upload function
    }
}

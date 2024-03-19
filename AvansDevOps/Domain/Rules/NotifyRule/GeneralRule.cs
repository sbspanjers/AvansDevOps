using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Rules.NotifyRule;

public class GeneralRule : INotifyRule
{
    public List<User> Filter(List<User> users)
    {
        return users;
    }
}
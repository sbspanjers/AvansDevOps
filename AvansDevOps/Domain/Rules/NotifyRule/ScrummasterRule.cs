using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Users;

namespace AvansDevOps.Domain.Rules.NotifyRule;

public class ScrummasterRule : INotifyRule
{
    public List<User> Filter(List<User> users)
    {
        return users.Where(u => u is Scrummaster).ToList();
    }
}

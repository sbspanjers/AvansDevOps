using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Users;

namespace AvansDevOps.Domain.Rules.NotifyRule;

public class POScrummasterRule : INotifyRule
{
    public List<User> Filter(List<User> users)
    {
        return users.Where(u => (u is Scrummaster) || (u is ProductOwner)).ToList();
    }
}

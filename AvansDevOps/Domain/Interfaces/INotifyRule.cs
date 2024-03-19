namespace AvansDevOps.Domain.Interfaces;

public interface INotifyRule
{
    List<User> Filter(List<User> users);
}
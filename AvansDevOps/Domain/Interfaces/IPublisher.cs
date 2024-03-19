namespace AvansDevOps.Domain.Interfaces;

public interface IPublisher
{
    void AddSubscriber(ISubscriber subscriber);
    void RemoveSubscriber(ISubscriber subscriber);
    void NotifySubscribers(string message, INotifyRule notifyRule);
}

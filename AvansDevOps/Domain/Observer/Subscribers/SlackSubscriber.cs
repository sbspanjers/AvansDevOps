using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Observer.Subscribers;

public class SlackSubscriber : ISubscriber
{
    public void Notify(string message, string userName)
    {
        Console.WriteLine($"SlackSubscriber: {userName} received a message: {message}");
    }
}


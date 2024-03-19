using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Observer.Subscribers;

public class GMailSubscriber : ISubscriber
{
    public void Notify(string message, string userName)
    {
        Console.WriteLine($"GMailSubscriber: {userName} received a message: {message}");
    }
}


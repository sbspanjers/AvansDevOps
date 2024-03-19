using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Observer.Subscribers;

public class WhatsappSubscriber : ISubscriber
{
    public void Notify(string message, string userName)
    {
        Console.WriteLine($"WhatsappSubscriber: {userName} received a message: {message}");
    }
}

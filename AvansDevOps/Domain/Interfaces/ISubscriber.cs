namespace AvansDevOps.Domain.Interfaces;

public interface ISubscriber
{
    void Notify(string message, string userName);
}
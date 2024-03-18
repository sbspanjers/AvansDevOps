using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Domain.Interfaces;

namespace AvansDevOps.Domain.Observer;

public class Publisher
{
    private List<ISubscriber> _subscribers = new();

    public void AddSubscriber(ISubscriber subscriber)
    {
        this._subscribers.Add(subscriber);
    }

    public void RemoveSubscriber(ISubscriber subscriber)
    {
        this._subscribers.Remove(subscriber);
    }

    public void NotifySubscribers()
    {
        foreach (var subscriber in this._subscribers)
        {
            subscriber.Notify();
        }
    }
}

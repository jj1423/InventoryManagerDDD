using Domain.Common;
using MediatR;

namespace Application.Common
{
    /// <summary>
    /// Class to implement the INotification interface for a domain event
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DomainEventNotification<T> : INotification where T : DomainEvent
    {
        public T DomainEvent { get; }

        public DomainEventNotification(T domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}

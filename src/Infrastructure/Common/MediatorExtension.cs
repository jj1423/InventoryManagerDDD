using Application.Common;
using Domain.Common;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    /// <summary>
    /// Extension method for the mediator class
    /// </summary>
    public static class MediatorExtension
    {
        /// <summary>
        /// Dispatches all pending domain events
        /// </summary>
        /// <param name="mediator">Reference to the mediator</param>
        /// <param name="context">Context of the application</param>
        /// <returns></returns>
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, InventoryDbContext context)
        {
            var entitiesWithEvents = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = entitiesWithEvents
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            entitiesWithEvents.ToList().ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                var notification = GetNotificationCorrespondingToDomainEvent(domainEvent);
                await mediator.Publish(notification);
            }
        }

        /// <summary>
        /// Extract the notification associated with the domain event
        /// </summary>
        /// <param name="domainEvent">Domain event that contains the notification</param>
        /// <returns>The notification associated to the domain event</returns>
        private static INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            return (INotification)Activator.CreateInstance(
                typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent)!;
        }
    }
}

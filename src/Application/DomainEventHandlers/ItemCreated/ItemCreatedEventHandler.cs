using Application.Common;
using Domain.Contracts.Logging;
using Domain.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DomainEventHandlers.ItemCreated
{
    /// <summary>
    /// Event handler for the item created event
    /// </summary>
    public class ItemCreatedEventHandler : INotificationHandler<DomainEventNotification<ItemCreatedEvent>>
    {
        private readonly ILogging _logger;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="loggingFactory">Logging factory injected to create a new logger</param>
        public ItemCreatedEventHandler(ILoggingFactory loggingFactory)
        {
            _logger = loggingFactory.CreateLogger(typeof(ItemCreatedEventHandler));
        }

        /// <summary>
        /// Handles the notification of the event
        /// </summary>
        /// <param name="notification">Notification of the event</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return a task</returns>
        public Task Handle(DomainEventNotification<ItemCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            _logger.LogInformation("Domain Event {0} ocurred at {1} for item {2}", domainEvent.GetType().Name, domainEvent.DateOccurred, domainEvent.Item);
            return Task.CompletedTask;
        }
    }
}

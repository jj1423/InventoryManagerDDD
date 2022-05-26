using Application.Common;
using Domain.Contracts.Logging;
using Domain.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DomainEventHandlers.ItemRemoved
{
    /// <summary>
    /// Event handler for the item removed event
    /// </summary>
    public class ItemRemovedEventHandler : INotificationHandler<DomainEventNotification<ItemRemovedEvent>>
    {
        private readonly ILogging _logger;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="loggingFactory">Logging factory injected to create a new logger</param>
        public ItemRemovedEventHandler(ILoggingFactory loggingFactory)
        {
            _logger = loggingFactory.CreateLogger(typeof(ItemRemovedEventHandler));
        }

        /// <summary>
        /// Handles the notification of the event
        /// </summary>
        /// <param name="notification">Notification of the event</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return a task</returns>
        public Task Handle(DomainEventNotification<ItemRemovedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            _logger.LogInformation("Domain Event {0} ocurred at {1} for item {2}", domainEvent.GetType().Name, domainEvent.DateOccurred, domainEvent.Item);
            return Task.CompletedTask;
        }
    }
}

using Application.Common;
using Domain.Contracts.Logging;
using Domain.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DomainEventHandlers.ItemExpired
{
    /// <summary>
    /// Event handler for the item expired event
    /// </summary>
    public class ItemExpiredEventHandler : INotificationHandler<DomainEventNotification<ItemExpiredEvent>>
    {
        private readonly ILogging _logger;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="loggingFactory">Logging factory injected to create a new logger</param>
        public ItemExpiredEventHandler(ILoggingFactory loggingFactory)
        {
            _logger = loggingFactory.CreateLogger(typeof(ItemExpiredEventHandler));
        }

        /// <summary>
        /// Handles the notification of the event
        /// </summary>
        /// <param name="notification">Notification of the event</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return a task</returns>
        public Task Handle(DomainEventNotification<ItemExpiredEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            _logger.LogWarning("Domain Event {0} ocurred at {1} for item {2}", domainEvent.GetType().Name, domainEvent.DateOccurred, domainEvent.Item);
            return Task.CompletedTask;
        }
    }
}

using System;

namespace Domain.Common
{
    /// <summary>
    /// Base class for domain events
    /// </summary>
    public abstract class DomainEvent
    {
        /// <summary>
        /// Flag which indicates if the event has been published
        /// </summary>
        //public bool IsPublished { get; set; }

        /// <summary>
        /// Date when the event occurred
        /// </summary>
        public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;

        /// <summary>
        /// Constructor without params that sets the Date
        /// </summary>
        protected DomainEvent()
        {
            DateOccurred = DateTime.UtcNow;
        }
    }
}

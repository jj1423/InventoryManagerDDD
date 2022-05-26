using System.Collections.Generic;

namespace Domain.Common
{
    /// <summary>
    /// Base class for an entity of domain
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Entity identifier
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// List with the pending events of the entity
        /// </summary>
        private List<DomainEvent> _domainEvents;

        /// <summary>
        /// Gets the domain events list
        /// </summary>
        public List<DomainEvent> DomainEvents => _domainEvents;

        /// <summary>
        /// Add a new domain event to the entity
        /// </summary>
        /// <param name="eventItem">Domain event to add</param>
        public void AddDomainEvent(DomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<DomainEvent>();
            _domainEvents.Add(eventItem);
        }

        /// <summary>
        /// Removes a domain event from the entity
        /// </summary>
        /// <param name="eventItem">Domain event to remove</param>
        public void RemoveDomainEvent(DomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        /// <summary>
        /// Removes all the domain events for the entity
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}

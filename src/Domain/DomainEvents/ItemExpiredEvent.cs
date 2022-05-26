using Domain.AggregatesModel.ItemAggregate;
using Domain.Common;

namespace Domain.DomainEvents
{
    /// <summary>
    /// Item expired event
    /// </summary>
    public class ItemExpiredEvent : DomainEvent
    {
        public Item Item { get; }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="item">Expired item</param>
        public ItemExpiredEvent(Item item)
        {
            Item = item;
        }
    }
}

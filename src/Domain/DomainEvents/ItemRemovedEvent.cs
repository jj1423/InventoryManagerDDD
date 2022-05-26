using Domain.AggregatesModel.ItemAggregate;
using Domain.Common;

namespace Domain.DomainEvents
{
    /// <summary>
    /// Item removed event
    /// </summary>
    public class ItemRemovedEvent : DomainEvent
    {
        public Item Item { get; }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="item">Removed item</param>
        public ItemRemovedEvent(Item item)
        {
            Item = item;
        }
    }
}

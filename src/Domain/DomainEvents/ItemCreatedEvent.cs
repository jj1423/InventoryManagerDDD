using Domain.AggregatesModel.ItemAggregate;
using Domain.Common;

namespace Domain.DomainEvents
{
    public class ItemCreatedEvent : DomainEvent
    {
        public Item Item { get; }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="item">Created item</param>
        public ItemCreatedEvent(Item item)
        {
            Item = item;
        }
    }
}

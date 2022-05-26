using Domain.Common;
using Domain.Common.MarkerInterfaces;
using Domain.DomainEvents;
using System;

namespace Domain.AggregatesModel.ItemAggregate
{
    /// <summary>
    /// Class that represents the domain entity of an Item
    /// </summary>
    public class Item : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public DateTime ExpirationDate { get; set; }
        public float Weight { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Item()
        {
            // It is necessary to avoid adding a new event when the constructor is invoked when an entity is caught from the database
        }

        /// <summary>
        /// Item constructor
        /// </summary>
        /// <param name="name">Item name</param>
        /// <param name="description">Item description</param>
        /// <param name="type">Item type</param>
        /// <param name="expirationDate">Item expiration date</param>
        /// <param name="weight">Item weight</param>
        public Item(string name, string description, ItemType type, DateTime expirationDate, float weight)
        {
            Name = name;
            Description = description;
            Type = type;
            ExpirationDate = expirationDate;
            Weight = weight;

            // Add the item created event
            AddDomainEvent(new ItemCreatedEvent(this));
        }

        /// <summary>
        /// Adds a new ItemRemovedEvent
        /// </summary>
        public void RemoveItemFromInventory()
        {
            // Some business logic...
            AddDomainEvent(new ItemRemovedEvent(this));
        }

        /// <summary>
        /// Adds a new ItemRemovedEvent
        /// </summary>
        public void SetItemAsExpired()
        {
            // Some business logic...
            AddDomainEvent(new ItemExpiredEvent(this));
        }

        /// <summary>
        /// Overrides the ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{Id={Id}, Name={Name}, Description={Description}, Type={Type}, Expiration Date={ExpirationDate}, Weight={Weight}}}";
        }
    }
}

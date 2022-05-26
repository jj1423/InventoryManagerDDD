using Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.ItemAggregate
{
    /// <summary>
    /// Interface for item repository
    /// </summary>
    public interface IItemRepository : IRepository<Item>
    {
        /// <summary>
        /// Returns an item by name
        /// </summary>
        /// <param name="name">Name of the item</param>
        /// <returns>Task which result contains the item found (or null)</returns>
        Task<Item> GetByNameAsync(string name);

        /// <summary>
        /// Gets the expiration date of the items and returns which are expired
        /// </summary>
        /// <returns>Task which result contains a collection of expired items</returns>
        Task<IEnumerable<Item>> GetExpiredItems();
    }
}

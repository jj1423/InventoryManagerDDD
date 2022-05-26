using Domain.AggregatesModel.ItemAggregate;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Implementatio of ItemRepository
    /// </summary>
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="context">Inventory context</param>
        public ItemRepository(InventoryDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Returns an item by name
        /// </summary>
        /// <param name="name">Name of the item</param>
        /// <returns></returns>
        public async Task<Item> GetByNameAsync(string name)
        {
            return await _dbSet.Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the expiration date of the items and returns which are expired
        /// </summary>
        /// <returns>Task which result contains a collection of expired items</returns>
        public async Task<IEnumerable<Item>> GetExpiredItems()
        {
            return await _dbSet.Where(i => i.ExpirationDate < DateTime.UtcNow).ToListAsync();
        }
    }
}

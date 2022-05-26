using Domain.Common;
using Domain.Contracts;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of the generic repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly InventoryDbContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="context">Inventory context</param>
        public Repository(InventoryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Returs all elements of a domain entity
        /// </summary>
        /// <returns>Task which result contains a collection of entities</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Returns a domain entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Task which result contains the entity</returns>
        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Adds a new domain entity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>Task which result contains the entity id</returns>
        public async Task<int> AddAsync(T entity)
        {
            var res = await _dbSet.AddAsync(entity);
            return res.Entity.Id;
        }

        /// <summary>
        /// Updates a domain entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns></returns>
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}

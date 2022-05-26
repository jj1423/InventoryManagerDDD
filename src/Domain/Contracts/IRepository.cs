using Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    /// <summary>
    /// Interface for repositories
    /// </summary>
    /// <typeparam name="T">Generic aggregate root entity</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Returs all elements of a domain entity
        /// </summary>
        /// <returns>Task which result contains a collection of entities</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Returns a domain entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Task which result contains the entity</returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Adds a new domain entity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>Task which result contains the entity id</returns>
        Task<int> AddAsync(T entity);

        /// <summary>
        /// Updates a domain entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns></returns>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Delete(T entity);
    }
}

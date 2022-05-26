using Domain.AggregatesModel.ItemAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    /// <summary>
    /// Interface for the unit of work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region Repositories

        IItemRepository Items { get; }
        // Another repositories...

        #endregion

        /// <summary>
        /// Saves the changes applying these over the database. It also raises pending domain events
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries wirtten to the database</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

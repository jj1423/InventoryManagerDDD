using Domain.AggregatesModel.ItemAggregate;
using Domain.Contracts;
using Infrastructure.Common;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDbContext _context;
        private readonly IMediator _mediator;
        private bool _disposed = false;

        #region Repositories

        public IItemRepository Items { get; }

        #endregion

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="context">Inventory context</param>
        /// <param name="mediator">Mediator</param>
        /// <param name="itemRepository">Abstraction of item repository</param>
        public UnitOfWork(InventoryDbContext context, IMediator mediator, IItemRepository itemRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            Items = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }

        /// <summary>
        /// Saves the changes applying these over the database. It also raises pending domain events
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries wirtten to the database</returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // Dispatches all pending domain events (just before to save the context)
            await _mediator.DispatchDomainEventsAsync(_context);

            // All pending changes in the context are committed
            var result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }

        /// <summary>
        /// Implements the dispose method 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the context
        /// </summary>
        /// <param name="disposing">Flag to indicates if it is a disposing action</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}

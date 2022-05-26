using Domain.Contracts;
using Domain.Contracts.Logging;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Application.BackgroundTasks
{
    /// <summary>
    /// Class which inherits from background service to check the expiration date of items in background
    /// </summary>
    public class ExpirationDateService : BackgroundService
    {
        private readonly ILogging _logger;
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="loggingFactory">Logging factory injected to create a new logger</param>
        /// <param name="factory">Service scope factory</param>
        public ExpirationDateService(ILoggingFactory loggingFactory, IServiceScopeFactory factory)
        {
            _logger = loggingFactory.CreateLogger(typeof(ExpirationDateService));
            _uow = factory.CreateScope().ServiceProvider.GetRequiredService<IUnitOfWork>();
        }

        /// <summary>
        /// Task to execute in background; in this case, checks the expiration date
        /// </summary>
        /// <param name="stoppingToken">Cancellation token</param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Checking expiration date service...");
                var expiredItems = await _uow.Items.GetExpiredItems();
                expiredItems.ToList().ForEach(i => i.SetItemAsExpired());
                await _uow.SaveChangesAsync(); // This will notify the expired events
                await Task.Delay(60 * 1000, stoppingToken); // Every minute only for debug
            }
        }

        /// <summary>
        /// Start method overwritten to add a log
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting background service...");
            await base.StartAsync(cancellationToken);
        }

        /// <summary>
        /// Stop method overwritten to add a log
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stoping background service...");
            await base.StopAsync(cancellationToken);
        }
    }
}

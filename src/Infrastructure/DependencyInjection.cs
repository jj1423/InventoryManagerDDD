using Domain.AggregatesModel.ItemAggregate;
using Domain.Contracts;
using Domain.Contracts.Logging;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<InventoryDbContext>(options => options.UseInMemoryDatabase("InventoryDb"));
            services.AddSingleton<ILoggingFactory, LoggingFactory>(); // Adds the logging factory as singleton
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}

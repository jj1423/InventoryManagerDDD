using Domain.AggregatesModel.ItemAggregate;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        // More DbSets....

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BaseEntityTypeConfiguration());
            // More configurations...
        }
    }
}

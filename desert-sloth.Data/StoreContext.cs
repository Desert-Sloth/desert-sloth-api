using Microsoft.EntityFrameworkCore;
using desert.sloth.Domain.Catalog;
using desert.sloth.Domain.Orders;

namespace desert.sloth.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders  { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitializer.Initialize(builder);
        }
    }
}
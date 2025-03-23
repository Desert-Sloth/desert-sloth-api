using desert.sloth.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace desert_sloth.Data
{
    public class StoreContext : DbContext
    {
         public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
    }
}


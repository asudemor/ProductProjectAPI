using Microsoft.EntityFrameworkCore;
using ProductProjectAPI.Core;

namespace ProductProjectAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ProductEntity> productEntities { get; set; }

    }
}

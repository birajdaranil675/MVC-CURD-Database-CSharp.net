using Microsoft.EntityFrameworkCore;

namespace CURDOperation.DBContext
{
    public class ProductDBContext: DbContext
    {
        public ProductDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set;}
    }
}

using Microsoft.EntityFrameworkCore;

namespace DataAccessTutorial.Web.Models
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products {get; set;}

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options): base(options)
        {
        }
    }
}

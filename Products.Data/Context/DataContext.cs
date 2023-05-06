using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Products.Domain.Entities;

namespace Products.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ProductReferences> References { get; set; }
        public DbSet<ProductQATests> ProductsQATests { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }

    //Criar o context no tempo de design
    public class DataContextContextFactory : IDesignTimeDbContextFactory<DataContext>
    {   public IConfiguration Configuration { get; set; }
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            return new DataContext(optionsBuilder.Options);
        }
    }
}

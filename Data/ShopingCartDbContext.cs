using Microsoft.EntityFrameworkCore;
using ShopingCart.API.Models.Domain;

namespace ShopingCart.API.Data
{
    public class ShopingCartDbContext :DbContext
    {
        public ShopingCartDbContext(DbContextOptions dbContextOptions):base(dbContextOptions) 
        {
                
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}

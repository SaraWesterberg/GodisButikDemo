using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candymania.Models
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Costumers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        
        
        
        
            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:sarawserver.database.windows.net,1433;Initial Catalog=MyDbSara;Persist Security Info=False;User ID=SaraWesterberg;Password=MyPassword1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;;");
        }
    }
}

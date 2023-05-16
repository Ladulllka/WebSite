using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Xml;
using WarehouseApi2.Model;

namespace WarehouseApi2
{
    public class ContextDB : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WarehouseDataBase;Username=postgres;Password=0000");
        }

        public ContextDB()
        {
            Database.EnsureCreated();
        }


        public DbSet<Carryngs> carryng { get; set; }
        public DbSet<Warehouse> warehouse { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Sales> sales { get; set; }
        public DbSet<Category> category { get; set; }


    }
}
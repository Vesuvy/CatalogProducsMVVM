using CatalogProductsMVVM.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;


namespace CatalogProductsMVVM.Utilities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-0BEQOP00\\SQLEXPRESS;Database=Makarov_Catalog_DB;Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}

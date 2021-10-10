using Microsoft.EntityFrameworkCore;
using ShoeWorkshop.Domain.Models;

namespace ShoeWorkshop.Database
{
    public class ShoeWorkshopDbContext : DbContext
    {
        public ShoeWorkshopDbContext() { }
        public ShoeWorkshopDbContext(DbContextOptions<ShoeWorkshopDbContext> options) : base(options) { }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ShoeWorkshop");
            modelBuilder.ApplyConfiguration(new WorkersConfiguration());
            modelBuilder.ApplyConfiguration(new CustomersConfiguration());
            modelBuilder.ApplyConfiguration(new RepairsConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

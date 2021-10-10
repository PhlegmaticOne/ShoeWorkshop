using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShoeWorkshop.Database
{
    public class ShoeWorkshopDbContextFactory : IDesignTimeDbContextFactory<ShoeWorkshopDbContext>
    {
        public ShoeWorkshopDbContext CreateDbContext(string[] args = null) =>
            new ShoeWorkshopDbContext(
                new DbContextOptionsBuilder<ShoeWorkshopDbContext>()
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ShoeWorkshopDatabase;Trusted_Connection=True;")
                    .Options
                );
    }
}

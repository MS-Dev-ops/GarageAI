using GarageAI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GarageAI.Infrastructure.Persistence;

public class GarageDbContextFactory : IDesignTimeDbContextFactory<GarageDbContext>
{
    public GarageDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GarageDbContext>();

        optionsBuilder.UseSqlServer(
              "Server=MSarwar-X1;Database=GarageAI;Trusted_Connection=True;TrustServerCertificate=True;");

        return new GarageDbContext(optionsBuilder.Options);
    }
}
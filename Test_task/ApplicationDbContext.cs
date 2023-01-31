using ConsoleApp30;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext, IAsyncStorage<Configuration>
{
    public ApplicationDbContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<Configuration> Configurations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase("ConfigurationDB");
        }
    }

    public async Task<IEnumerable<Configuration>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await Configurations.ToListAsync(cancellationToken);
    }

    public async Task<int> SetAsync(IEnumerable<Configuration> items, CancellationToken cancellationToken = default)
    {
        await Configurations.AddRangeAsync(items, cancellationToken);

        return await SaveChangesAsync(cancellationToken);
    }
}
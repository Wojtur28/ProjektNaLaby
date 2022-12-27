
namespace Projekt.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Game> Games => Set<Game>();
    public DbSet<User> Users => Set<User>();
}
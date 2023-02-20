using Microsoft.EntityFrameworkCore;

namespace MinifiguresAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<BoardGame> BoardGame => Set<BoardGame>();

    }
};

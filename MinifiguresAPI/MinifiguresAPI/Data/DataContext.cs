using Microsoft.EntityFrameworkCore;
using MinifiguresAPI.Models;

namespace MinifiguresAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<BoardGame> BoardGame => Set<BoardGame>();

    }
};

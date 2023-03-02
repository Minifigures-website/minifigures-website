global using Microsoft.EntityFrameworkCore;
using MinifiguresAPI.Models;

namespace MinifiguresAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=boardgamedb;trusted_connection=true;TrustServerCertificate=True");
        }

        public DbSet<BoardGame> BoardGames { get; set; }
    }

};

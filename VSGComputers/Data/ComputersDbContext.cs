using Microsoft.EntityFrameworkCore;
using VSGComputers.Models;

namespace VSGComputers.Data
{
    public class ComputersDbContext : DbContext
    {
        public ComputersDbContext(DbContextOptions<ComputersDbContext> options) : base(options)
        {   
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computer>().HasData(
                new Computer(1, "I7", "RTX 4050", 16, 1000, "z370", "NZXT"),
                new Computer(2, "I5", "RTX 4060", 32, 1000, "z720", "AirMaster")
                );
        }

        public DbSet<Computer> Computers { get; set; }
    }
}

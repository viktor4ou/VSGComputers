using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VSGComputers.Models;
using VSGComputers.Models.Models;

namespace VSGComputers.Data
{
    public class ComputersDbContext : IdentityDbContext<IdentityUser>
    {
        public ComputersDbContext(DbContextOptions<ComputersDbContext> options) : base(options)
        {

        }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Computer>().HasData(
                new Computer(1, "I7", "RTX 4050", 16, 1000, "z370", "NZXT", ""),
                new Computer(2, "I5", "RTX 4060", 32, 1000, "z720", "AirMaster", "")
                );
        }

    }
}

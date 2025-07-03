// Data/ApplicationDbContext.cs
using app_example.Controllers.API.User;
using app_example.Models;
using app_example.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app_example.Data

{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Register your models as DbSet
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<WiiBandMonitor> WiiBandMonitor { get; set; }
        public DbSet<WiiBandTag> WiiBandTag { get; set; }
        public DbSet<WiiBandMaster> WiiBandMaster { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            // Tell EF Core that TagId is the PK for WiiBandMaster
            modelBuilder.Entity<WiiBandMaster>()
                .HasKey(w => w.TagId);
        }

    }
}
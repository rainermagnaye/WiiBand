﻿// Data/ApplicationDbContext.cs
using app_example.Models;
using app_example.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app_example.Data

{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) {}

        // Register your models as DbSet
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Summary> Summaries { get; set; }  // Analytics Summary (Daily, Weekly, Monthly) 
        public DbSet<Branch> Branches { get; set; } // Branches



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Customer>()
        //        .HasIndex(c => c.Email)
        //        .IsUnique();
        //}


    }
}

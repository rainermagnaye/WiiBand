// Data/ApplicationDbContext.cs
using app_example.Models;
using app_example.Models.Admin;
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
        public DbSet<Event> Events { get; set; }
        public DbSet<DailyParkSales> DailyParkSales { get; set; }
        public DbSet<ForecastedData> ForecastedData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DailyParkSales>().HasData(
                new DailyParkSales { Id = 1, Date = new DateTime(2022, 7, 1), DayOfWeek = "Friday", GeneralAdmission = 120, ExtendedHour = 25, PWDGeneralAdmission = 6, EarlyJump = 8, OverallPaxQty = 159, OverallPaxAmount = 15900m },
                new DailyParkSales { Id = 2, Date = new DateTime(2022, 7, 2), DayOfWeek = "Saturday", GeneralAdmission = 160, ExtendedHour = 30, PWDGeneralAdmission = 7, EarlyJump = 10, OverallPaxQty = 207, OverallPaxAmount = 20700m },
                new DailyParkSales { Id = 3, Date = new DateTime(2022, 7, 3), DayOfWeek = "Sunday", GeneralAdmission = 150, ExtendedHour = 28, PWDGeneralAdmission = 6, EarlyJump = 9, OverallPaxQty = 193, OverallPaxAmount = 19300m },
                new DailyParkSales { Id = 4, Date = new DateTime(2022, 7, 4), DayOfWeek = "Monday", GeneralAdmission = 110, ExtendedHour = 20, PWDGeneralAdmission = 5, EarlyJump = 6, OverallPaxQty = 141, OverallPaxAmount = 14100m },
                new DailyParkSales { Id = 5, Date = new DateTime(2022, 7, 5), DayOfWeek = "Tuesday", GeneralAdmission = 105, ExtendedHour = 18, PWDGeneralAdmission = 5, EarlyJump = 5, OverallPaxQty = 133, OverallPaxAmount = 13300m },
                new DailyParkSales { Id = 6, Date = new DateTime(2022, 7, 6), DayOfWeek = "Wednesday", GeneralAdmission = 108, ExtendedHour = 19, PWDGeneralAdmission = 4, EarlyJump = 6, OverallPaxQty = 137, OverallPaxAmount = 13700m },
                new DailyParkSales { Id = 7, Date = new DateTime(2022, 7, 7), DayOfWeek = "Thursday", GeneralAdmission = 112, ExtendedHour = 20, PWDGeneralAdmission = 5, EarlyJump = 6, OverallPaxQty = 143, OverallPaxAmount = 14300m },
                new DailyParkSales { Id = 8, Date = new DateTime(2022, 7, 8), DayOfWeek = "Friday", GeneralAdmission = 125, ExtendedHour = 23, PWDGeneralAdmission = 6, EarlyJump = 8, OverallPaxQty = 162, OverallPaxAmount = 16200m },
                new DailyParkSales { Id = 9, Date = new DateTime(2022, 7, 9), DayOfWeek = "Saturday", GeneralAdmission = 165, ExtendedHour = 31, PWDGeneralAdmission = 7, EarlyJump = 10, OverallPaxQty = 213, OverallPaxAmount = 21300m },
                new DailyParkSales { Id = 10, Date = new DateTime(2022, 7, 10), DayOfWeek = "Sunday", GeneralAdmission = 155, ExtendedHour = 29, PWDGeneralAdmission = 6, EarlyJump = 9, OverallPaxQty = 199, OverallPaxAmount = 19900m },
                new DailyParkSales { Id = 11, Date = new DateTime(2022, 7, 11), DayOfWeek = "Monday", GeneralAdmission = 115, ExtendedHour = 21, PWDGeneralAdmission = 5, EarlyJump = 7, OverallPaxQty = 148, OverallPaxAmount = 14800m },
                new DailyParkSales { Id = 12, Date = new DateTime(2022, 7, 12), DayOfWeek = "Tuesday", GeneralAdmission = 110, ExtendedHour = 19, PWDGeneralAdmission = 5, EarlyJump = 6, OverallPaxQty = 140, OverallPaxAmount = 14000m },
                new DailyParkSales { Id = 13, Date = new DateTime(2022, 7, 13), DayOfWeek = "Wednesday", GeneralAdmission = 113, ExtendedHour = 20, PWDGeneralAdmission = 5, EarlyJump = 6, OverallPaxQty = 144, OverallPaxAmount = 14400m },
                new DailyParkSales { Id = 14, Date = new DateTime(2022, 7, 14), DayOfWeek = "Thursday", GeneralAdmission = 116, ExtendedHour = 21, PWDGeneralAdmission = 5, EarlyJump = 6, OverallPaxQty = 148, OverallPaxAmount = 14800m },
                new DailyParkSales { Id = 15, Date = new DateTime(2022, 7, 15), DayOfWeek = "Friday", GeneralAdmission = 128, ExtendedHour = 24, PWDGeneralAdmission = 6, EarlyJump = 8, OverallPaxQty = 166, OverallPaxAmount = 16600m },
                new DailyParkSales { Id = 16, Date = new DateTime(2022, 7, 16), DayOfWeek = "Saturday", GeneralAdmission = 170, ExtendedHour = 32, PWDGeneralAdmission = 7, EarlyJump = 10, OverallPaxQty = 219, OverallPaxAmount = 21900m },
                new DailyParkSales { Id = 17, Date = new DateTime(2022, 7, 17), DayOfWeek = "Sunday", GeneralAdmission = 158, ExtendedHour = 30, PWDGeneralAdmission = 6, EarlyJump = 9, OverallPaxQty = 203, OverallPaxAmount = 20300m },
                new DailyParkSales { Id = 18, Date = new DateTime(2022, 7, 18), DayOfWeek = "Monday", GeneralAdmission = 117, ExtendedHour = 21, PWDGeneralAdmission = 5, EarlyJump = 7, OverallPaxQty = 150, OverallPaxAmount = 15000m },
                new DailyParkSales { Id = 19, Date = new DateTime(2022, 7, 19), DayOfWeek = "Tuesday", GeneralAdmission = 112, ExtendedHour = 19, PWDGeneralAdmission = 5, EarlyJump = 6, OverallPaxQty = 142, OverallPaxAmount = 14200m },
                new DailyParkSales { Id = 20, Date = new DateTime(2022, 7, 20), DayOfWeek = "Wednesday", GeneralAdmission = 115, ExtendedHour = 20, PWDGeneralAdmission = 5, EarlyJump = 6, OverallPaxQty = 146, OverallPaxAmount = 14600m },
                new DailyParkSales { Id = 21, Date = new DateTime(2022, 7, 21), DayOfWeek = "Thursday", GeneralAdmission = 118, ExtendedHour = 21, PWDGeneralAdmission = 5, EarlyJump = 6, OverallPaxQty = 150, OverallPaxAmount = 15000m },
                new DailyParkSales { Id = 22, Date = new DateTime(2022, 7, 22), DayOfWeek = "Friday", GeneralAdmission = 130, ExtendedHour = 25, PWDGeneralAdmission = 6, EarlyJump = 8, OverallPaxQty = 169, OverallPaxAmount = 16900m },
                new DailyParkSales { Id = 23, Date = new DateTime(2022, 7, 23), DayOfWeek = "Saturday", GeneralAdmission = 172, ExtendedHour = 33, PWDGeneralAdmission = 7, EarlyJump = 10, OverallPaxQty = 222, OverallPaxAmount = 22200m },
                new DailyParkSales { Id = 24, Date = new DateTime(2022, 7, 24), DayOfWeek = "Sunday", GeneralAdmission = 160, ExtendedHour = 31, PWDGeneralAdmission = 6, EarlyJump = 9, OverallPaxQty = 206, OverallPaxAmount = 20600m },
                new DailyParkSales { Id = 25, Date = new DateTime(2022, 7, 25), DayOfWeek = "Monday", GeneralAdmission = 120, ExtendedHour = 22, PWDGeneralAdmission = 5, EarlyJump = 7, OverallPaxQty = 154, OverallPaxAmount = 15400m },
                new DailyParkSales { Id = 26, Date = new DateTime(2022, 7, 26), DayOfWeek = "Tuesday", GeneralAdmission = 114, ExtendedHour = 20, PWDGeneralAdmission = 5, EarlyJump = 6, OverallPaxQty = 145, OverallPaxAmount = 14500m },
                new DailyParkSales { Id = 27, Date = new DateTime(2022, 7, 27), DayOfWeek = "Wednesday", GeneralAdmission = 117, ExtendedHour = 21, PWDGeneralAdmission = 5, EarlyJump = 6, OverallPaxQty = 149, OverallPaxAmount = 14900m },
                new DailyParkSales { Id = 28, Date = new DateTime(2022, 7, 28), DayOfWeek = "Thursday", GeneralAdmission = 120, ExtendedHour = 22, PWDGeneralAdmission = 5, EarlyJump = 6, OverallPaxQty = 153, OverallPaxAmount = 15300m },
                new DailyParkSales { Id = 29, Date = new DateTime(2022, 7, 29), DayOfWeek = "Friday", GeneralAdmission = 132, ExtendedHour = 26, PWDGeneralAdmission = 6, EarlyJump = 8, OverallPaxQty = 172, OverallPaxAmount = 17200m },
                new DailyParkSales { Id = 30, Date = new DateTime(2022, 7, 30), DayOfWeek = "Saturday", GeneralAdmission = 175, ExtendedHour = 34, PWDGeneralAdmission = 7, EarlyJump = 10, OverallPaxQty = 226, OverallPaxAmount = 22600m },
                new DailyParkSales { Id = 31, Date = new DateTime(2022, 7, 31), DayOfWeek = "Sunday", GeneralAdmission = 162, ExtendedHour = 32, PWDGeneralAdmission = 6, EarlyJump = 9, OverallPaxQty = 209, OverallPaxAmount = 20900m }
                );
        }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Customer>()
        //        .HasIndex(c => c.Email)
        //        .IsUnique();
        //}


    }
}

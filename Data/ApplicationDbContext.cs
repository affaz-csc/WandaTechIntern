using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wandaTechIntern.Data.Models;
using wandaTechIntern.Service;

namespace wandaTechIntern.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        public DbSet<MyDelivery> MyDeliveries { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Delivery>()
        //    //    .HasData(
        //    //        new Delivery
        //    //        {
        //    //            PostedTime = DateTime.Now,
        //    //            TimeOfDelivery = DateTime.Now.AddDays(1),
        //    //            TotalPoints = 1,
        //    //            TotalValue = 100,
        //    //            DeliveryPoints = new List<DeliveryPoint>
        //    //            {
        //    //                new DeliveryPoint
        //    //                {
        //    //                    ContactName = "Wanda",
        //    //                    ContactPhone = "99898656",
        //    //                    Latitude = 3.2545466,
        //    //                    Longitude = 74.2545466
        //    //                }
        //    //            }
        //    //        },
        //    //        new Delivery
        //    //        {
        //    //            PostedTime = DateTime.Now,
        //    //            TimeOfDelivery = DateTime.Now.AddDays(2),
        //    //            TotalPoints = 2,
        //    //            TotalValue = 150,
        //    //        }
        //    //    );

        //}
    }
}
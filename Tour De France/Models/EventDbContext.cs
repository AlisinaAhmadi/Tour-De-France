using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tour_De_France.Models
{
    public class EventDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EventTourDeFranceDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Deltager> Deltagere { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Musiktelt> Musiktelte { get; set; }
        public DbSet<Parking_plads> ParkingPlads { get; set; }
        public DbSet<Spisetelt> Spisetelte { get; set; }
        public DbSet<Togafgang> Togafgange { get; set; }
        public DbSet<Tribune> Tribuner { get; set; }
        public DbSet<VIP> VIPs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<EventOrder> EventOrders { get; set; }
    }
}

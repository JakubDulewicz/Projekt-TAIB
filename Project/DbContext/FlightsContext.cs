using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class FlightsContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Airline> Airlane { get; set; }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Plane> Plane { get; set; }
        public DbSet<Ticket> Ticket { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TicketService;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flight>()
                .HasOne(x => x.AirportFrom)
                .WithOne(x => x.FlightFrom)
                .HasForeignKey<Flight>(x => x.AirportIdFrom);

            modelBuilder.Entity<Flight>()
                .HasOne(x => x.AirportTo)
                .WithOne(x => x.FlightTo)
                .HasForeignKey<Flight>(x => x.AirportIdTo);

            //modelBuilder.Entity<Flight>()
            //    .HasMany(x => x.Tickets)
            //    .WithOne(x => x.Flight)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Flight>()
            //    .HasOne(x => x.Plane)
            //    .WithOne(x => x.Flights)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

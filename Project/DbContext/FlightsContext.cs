using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class FlightsContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Airline> Airline { get; set; }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Plane> Plane { get; set; }
        public DbSet<Ticket> Ticket { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BiletyLotnicze;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            //This loop is necessary bc fluent API (somehow) setup cascade onDelete behavior which causes cyclical deletion
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

          /*  modelBuilder.Entity<Flight>()
                .HasOne(x => x.AirportFrom)
                .WithOne(x => x.FlightFrom)
                .HasForeignKey<Flight>(x => x.AirportIdFrom)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasOne(x => x.AirportTo)
                .WithOne(x => x.FlightTo)
                .HasForeignKey<Flight>(x => x.AirportIdTo)
                .OnDelete(DeleteBehavior.Restrict);*/
                
        }
    }
}

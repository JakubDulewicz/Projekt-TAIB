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
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TicketSite;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum Status
    {
        Active,
        Delayed,
        Cancelled,
        Departed,
        Arrived
    }
    public class Flight : IEntityTypeConfiguration<Flight>
    {
        [Key]
        public int FlightId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Destination { get; set; }

        [Required]
        public DateTime Departure { get; set; }

        [Required]
        public DateTime Arrival { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public int AirportToAirportId { get; set; }

        [Required]
        public int  AirportFromAirportId { get; set; }

        [Required]
        public int PlaneId { get; set; }

        public Airport AirportFrom { get; set; }
        public Airport AirportTo { get; set; }
        public Plane Plane { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder
                .HasMany(f => f.Tickets)
                .WithOne(t => t.Flight)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.AirportFrom)
                .WithMany()
                .HasForeignKey(f => f.AirportToAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.AirportTo)
                .WithMany()
                .HasForeignKey(f => f.AirportFromAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.Plane)
                .WithMany()
                .HasForeignKey(f => f.PlaneId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}

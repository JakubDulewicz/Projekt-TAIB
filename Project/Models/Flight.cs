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
        [Required,Column("ID")]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required,MaxLength(50)]
        public string Destination { get; set; }
        [Required]
        public DateTime Departure { get; set; }
        [Required]
        public DateTime Arrival { get;}
        [Required]
        public Status Status { get; set; }
        
        
        [Required]
        public int? AirportIdTo {  get; set; }
        [Required]
        public int? AirportIdFrom { get; set; }
        [Required]
        public int? PlaneId { get; set; }

        [Required]
        public Airport AirportFrom { get; set; }
        [Required]
        public Airport AirportTo { get; set; }
        [Required,ForeignKey(nameof(PlaneId))]
        public Plane Plane { get; set; }
        [Required]
        public IEnumerable<Ticket> Tickets { get; set; }

        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder
                .HasMany(x => x.Tickets)
                .WithOne(x => x.Flight)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Plane)
                .WithOne(x => x.Flights)
                .OnDelete(DeleteBehavior.Restrict);
            //builder
            //    .HasOne(x => x.AirportFrom)
            //    .WithOne(x => x.FlightFrom)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder
            //    .HasOne(x => x.AirportTo)
            //    .WithOne(x => x.FlightTo)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

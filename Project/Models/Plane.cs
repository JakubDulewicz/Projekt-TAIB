using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Plane : IEntityTypeConfiguration<Plane>
    {
        [Required,Column("ID")]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Model { get; set; }
        [Required]
        public DateOnly YearOfProduction { get; set; }
        [Required]
        public int SeatCount {  get; set; }
        [Required]
        public bool HasPrivateCabins { get; set; }
        public int FlightId { get; set; }
        [ForeignKey(nameof(FlightId))]
        public Flight Flights { get; set; }
        public int AirlineId { get; set; }
        [ForeignKey(nameof(AirlineId))]
        public Airline Airlines { get; set; }

        
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder
                .HasOne(x => x.Flights)
                .WithOne(x => x.Plane)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Airlines)
                .WithMany(x => x.Planes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

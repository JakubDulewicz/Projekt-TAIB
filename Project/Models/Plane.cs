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

        public Flight Flights { get; set; }
        public Airlane Airlanes { get; set; }

        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder
                .HasOne(x => x.Flights)
                .WithOne(x => x.Plane)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.Airlanes)
                .WithMany(x => x.Planes)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

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
        [Key]
        public int PlaneId { get; set; }

        [Required, MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public DateOnly YearOfProduction { get; set; }

        [Required]
        public int SeatCount { get; set; }

        [Required]
        public bool HasPrivateCabins { get; set; }

        public ICollection<Flight> Flights { get; set; }
        public Airline Airlines { get; set; }

        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            // Konfiguracja relacji może być dodana później, w zależności od potrzeb
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Airport : IEntityTypeConfiguration<Airport>
    {
        [Key]
        public int AirportId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string IATA_CODE { get; set; }

        [Required, MaxLength(50)]
        public string Country { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(50)]
        public string Address { get; set; }

        public int? PlaneId { get; set; }
        public ICollection<Plane> Planes { get; set; }

        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            // Konfiguracja relacji może być dodana później, w zależności od potrzeb
        }
    }
}


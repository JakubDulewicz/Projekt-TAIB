using Microsoft.EntityFrameworkCore;
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
    public class Airline : IEntityTypeConfiguration<Airline>
    {
        [Key]
        public int AirlineId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Country { get; set; }

        [Required, MaxLength(50)]
        public string Logo { get; set; }

        public ICollection<Plane> Planes { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder
                .HasMany(a => a.Tickets)
                .WithOne(t => t.Airlines)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(a => a.Planes)
                .WithOne(p => p.Airlines)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


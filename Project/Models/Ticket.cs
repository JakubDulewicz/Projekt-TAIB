using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum Class
    {
        First,
        Bussines,
        Economic
    }
    public class Ticket : IEntityTypeConfiguration<Ticket>
    {
        [Key]
        public int TicketId { get; set; }

        [Required, MaxLength(10)]
        public string Seat { get; set; }

        [Required]
        public Class Class { get; set; }

        [Required]
        public double Price { get; set; }

        public Users User { get; set; }
        public Flight Flight { get; set; }
        public Airline Airlines { get; set; }

        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Flight)
                .WithMany(f => f.Tickets)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Airlines)
                .WithMany(a => a.Tickets)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

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
        [Required,Column("ID")]
        public int Id { get; set; }
        [Required,MaxLength(10)]
        public string Seat { get; set; }
        [Required]
        public Class Class { get; set; }
        public Users User { get; set; }
        public int FlightId {  get; set; }
        [ForeignKey(nameof (FlightId))]
        public Flight Flight { get; set; }
        public int AirlineId { get; set; }
        [ForeignKey(nameof (AirlineId))]
        public Airline Airlines { get; set; }

        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Tickets)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Flight)
                .WithMany(x => x.Tickets)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Airlines)
                .WithMany(x => x.Tickets)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

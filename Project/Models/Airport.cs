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
        [Required,Column("ID")]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int IATA_CODE { get; set; }
        [Required,MaxLength(50)]
        public string Country {  get; set; }
        [Required,MaxLength(50)]
        public string City { get; set; }
        [Required,MaxLength(50)]
        public string Address { get; set; }
       
        [Required]
        public Flight FlightTo { get; set; }
        [Required]
        public Flight FlightFrom { get; set; }

        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            //builder
            //    .HasOne(x => x.FlightTo)
            //    .WithOne(x => x.AirportTo)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder
            //    .HasOne(x => x.FlightFrom)
            //    .WithOne(x => x.AirportFrom)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

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
    public class Airlane : IEntityTypeConfiguration<Airlane>
    {
        [Required,Column("ID")]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required,MaxLength (50)]
        public string Country { get; set; }
        [Required,MaxLength (50)]
        public string Logo { get; set; }
        [Required]
        public IEnumerable<Plane> Planes { get; set; }
        [Required]
        public IEnumerable<Ticket> Tickets { get; set; }

        public void Configure(EntityTypeBuilder<Airlane> builder)
        {
            throw new NotImplementedException();
        }
    }
}

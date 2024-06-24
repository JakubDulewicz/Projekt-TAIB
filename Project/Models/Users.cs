using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models
{
    public enum Roles
    {
        Admin,
        Client,
        Guest,
        Employee
    }
    public class Users : IEntityTypeConfiguration<Users>
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(11)]
        public string Pesel { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(500)]
        public string Password { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        public string Phone { get; set; }

        [Required]
        public Roles Roles { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder
                .HasMany(u => u.Tickets)
                .WithOne(t => t.User)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

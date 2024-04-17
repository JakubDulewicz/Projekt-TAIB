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
        [Key, Column("ID")]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(11)]
        public int Pesel { get;set; }
        [Required, MaxLength(50)]
        public string Email {  get; set; }
        [Required, MaxLength(20)]
        public string Password { get; set; }
        [Required]
        public DateOnly Date {  get; set; }
        public int Phone {  get; set; }
        [Required]
        public Roles Roles { get; set; }
        [Required]
        public int TicketId { get; set; }
        [ForeignKey(nameof(TicketId))]
        public IEnumerable<Ticket> Tickets { get; set; }

        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder
                .HasMany(x => x.Tickets)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

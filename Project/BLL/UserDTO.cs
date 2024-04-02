using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int Pesel { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public DateOnly Date { get; init; }
        public int Phone { get; init; }
        public Roles Roles { get; init; }
        public IEnumerable<Ticket> Tickets { get; init; }
    }
}

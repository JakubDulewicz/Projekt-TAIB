using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace BLL
{
    public class TicketDTO
    {
        public int Id { get; init; }
        public string Seat { get; init; }
        public Class Class { get; init; }
        public Users User { get; init; }
        public Flight Flight { get; init; }
        public Airline Airlines { get; init; }
    }
}

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
        public double Price { get; init; }
        public int UserId { get; set; }
        public int FlightId { get; init; }
        public int AirlineId { get; init; }
        public UserDTO? User { get; init; }
    }
}

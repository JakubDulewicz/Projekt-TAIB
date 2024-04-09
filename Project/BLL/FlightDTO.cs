using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace BLL
{
    public class FlightDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Destination { get; init; }
        public DateTime Departure {  get; init; }
        public DateTime Arrival { get; init; }
        public Status Status { get; init; }
        public int AirportToId { get; init; }
        public int AirportFromId { get; init; }
        public int PlaneId { get; init; }
        public IEnumerable<TicketDTO> Tickets { get; init; }

    }
}

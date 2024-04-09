using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IFlightService
    {
        Task CreateFlight(int flightId, string name, string destination, DateTime departure, DateTime arrival, Status status, int airportToId, int airprortFromId, int planeId);
        Task DeleteFlight(FlightDTO flightId);
        Task<IEnumerable<FlightDTO>> GetFlights(FlightDTO flightId);
    }
}

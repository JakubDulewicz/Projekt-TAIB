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
        Task DeleteFlight(int flightId);
        Task AssignPlanesAndAirports(int flightId, int planeid, int airportToId, int airportFromId);
        Task MovePlaneToDestination(int flightId, int planeId, int airportId);
        Task SetStatus(int flightId, Status newStatus);
        Task<IEnumerable<FlightDTO>> GetFlights();
    }
}

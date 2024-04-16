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
        Task CreateFlight(int flightId, string name, string destination, DateTime departure, DateTime arrival, Status status, AirportDTO airportToId, AirportDTO airprortFromId, PlaneDTO planeId);
        Task DeleteFlight(FlightDTO flightId);
        Task AssignPlanesAndAirports(int flightId, PlaneDTO plane, AirportDTO airportTo, AirportDTO airportFrom);
        Task MovePlaneToDestination(FlightDTO flight, PlaneDTO plane, AirportDTO airport);
        Task SetStatus(FlightDTO flight);
        Task<IEnumerable<FlightDTO>> GetFlights(FlightDTO flightId);
    }
}

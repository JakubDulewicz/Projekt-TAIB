using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IFlightService
    {
        Task CreateFlight(FlightDTO flightId);
        Task DeleteFlight(FlightDTO flightId);
        Task<IEnumerable<FlightDTO>> GetFlights(FlightDTO flightId);
    }
}

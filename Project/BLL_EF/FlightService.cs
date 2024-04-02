using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL_EF
{
    public class FlightService : IFlightService
    {
        public Task CreateFlight(FlightDTO flightId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFlight(FlightDTO flightId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FlightDTO>> GetFlights(FlightDTO flightId)
        {
            throw new NotImplementedException();
        }
    }
}

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
        public Task CreateFlight(int flightId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFlight(int flightId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<FlightDTO>> IFlightService.GetFlights(int flightId)
        {
            throw new NotImplementedException();
        }
    }
}

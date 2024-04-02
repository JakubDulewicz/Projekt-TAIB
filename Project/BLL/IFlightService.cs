using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IFlightService
    {
        Task CreateFlight(int flightId);
        Task DeleteFlight(int flightId);
        Task<IEnumerable<>>
    }
}

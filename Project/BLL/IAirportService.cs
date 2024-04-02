using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAirportService
    {
        Task AddAirport(int airportId);
        Task RemoveAirport(int airportId);

    }
}

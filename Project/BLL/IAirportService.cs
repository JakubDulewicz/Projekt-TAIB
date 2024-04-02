using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAirportService
    {
        Task AddAirport(AirportDTO airportId);
        Task RemoveAirport(AirportDTO airportId);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAirportService
    {
        Task AddAirport(AirportRequest request);
        Task RemoveAirport(int airportId);
        Task AssignPlaneToAirport(int airportId, int planeId);
        public Task<IEnumerable<AirportDTO>> GetAllAirports(); 
    }
}

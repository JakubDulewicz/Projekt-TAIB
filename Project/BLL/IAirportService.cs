using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAirportService
    {
        Task AddAirport(int airportId, string name, string IATA, string country, string city, string address);
        Task RemoveAirport(AirportDTO airportId);
        Task AssignPlaneToAirport(int airportId, PlaneDTO plane);
        public Task<IEnumerable<AirportDTO>> GetAllAirports(); 
    }
}

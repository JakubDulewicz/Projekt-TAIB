using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPlaneService
    {
        Task AddPlane(PlaneRequest request);
        Task AddFlightToPlane(FlightDTO flight);
        Task DeletePlane(int planeID);
        public Task<IEnumerable<PlaneRequest>> GetAllPlanes(); 
    }
}

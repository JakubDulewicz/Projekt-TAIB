using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class PlaneService : IPlaneService
    {
        readonly FlightsContext _flightsContext;
        public PlaneService(FlightsContext flightsContext)
        { 
            _flightsContext = flightsContext;
        }

        public Task AddFlightToPlane(FlightDTO flight)
        {
            throw new NotImplementedException();
        }

        public Task DeletePlane(int planeID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PlaneRequest>> GetAllPlanes()
        {
            var planes = await _flightsContext.Plane.ToListAsync();
            return planes.Select(plane => new PlaneRequest
            {
                Id = plane.PlaneId,
                Model = plane.Model,
                YearOfProduction = plane.YearOfProduction,
                SeatCount = plane.SeatCount,
                HasPrivateCabins = plane.HasPrivateCabins,
            });
        }
        public async Task AddPlane(PlaneRequest request)
        {
            var plane = new Models.Plane
            {
                //PlaneId = request.Id,
                Model = request.Model,
                YearOfProduction = request.YearOfProduction,
                SeatCount = request.SeatCount,
                HasPrivateCabins = request.HasPrivateCabins,
            };

            _flightsContext.Plane.Add(plane);
            await _flightsContext.SaveChangesAsync();
        }
    }
}

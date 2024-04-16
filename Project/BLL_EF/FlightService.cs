using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Models;

namespace BLL_EF
{
    public class FlightService : IFlightService
    {
        readonly IAirportService _airportService;

        public List<FlightDTO> _flights { get; set; }

        Task IFlightService.CreateFlight(int flightId, string name, string destination, DateTime departure, DateTime arrival, Status status, AirportDTO airportToId, AirportDTO airprortFromId, PlaneDTO planeId)
        {
            var flight = new FlightDTO()
            {
                Id = GenerateUniqueId(),
                Name = name,
                Destination = destination,
                Departure = departure,
                Arrival = arrival,
                Status = status
            };
            _flights.Add(flight);
            return Task.FromResult(AssignPlanesAndAirports(flightId, planeId, airportToId, airprortFromId));
        }

        private int GenerateUniqueId()
        {
            return new Random().Next(1, 100000);
        }

        public Task DeleteFlight(FlightDTO flightId)
        {
            var deletedFlight = _flights.FirstOrDefault(flightId);
            if(deletedFlight != null)
            {
                _flights.Remove(deletedFlight);
            }
            else
            {
                throw new ArgumentException($"Unable to delete flight {flightId}");
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<FlightDTO>> GetFlights(FlightDTO flightId)
        {
            IEnumerable<FlightDTO> flights = _flights;
            
            return Task.FromResult(flights);
        }

        public Task AssignPlanesAndAirports(int flightId, PlaneDTO plane, AirportDTO airportTo, AirportDTO airportFrom)
        {
            var assign = _flights.FirstOrDefault(f => f.Id == flightId);
            if(assign != null)
            {
                assign.AirportFromId = airportFrom.Id;
                assign.AirportToId = airportTo.Id;
                assign.PlaneId = plane.Id;
            }
            else
            {
                throw new ArgumentException($"Unable to assign plane {plane} with airport {airportFrom} and airport {airportTo}");
            }
            return Task.CompletedTask;
        }
        public Task SetStatus(FlightDTO flight)
        {
            var changeStatus = _flights.FirstOrDefault(f => f.Id == flight.Id);
            if(changeStatus != null)
            {
                changeStatus.Status = flight.Status;
            }
            else { throw new ArgumentException($"couldn't change status {changeStatus.Status} to {flight.Status}"); }
            return Task.CompletedTask;
        }
        public Task MovePlaneToDestination(FlightDTO flight, PlaneDTO plane, AirportDTO airport)
        {
            
        }


    }
}

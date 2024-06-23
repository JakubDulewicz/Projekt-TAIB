using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace BLL_EF
{
    public class FlightService : IFlightService
    {
        readonly FlightsContext _flightsContext;

        public FlightService(FlightsContext context)
        {
            _flightsContext = context;
        }

        public async Task AssignPlanesAndAirports(int flightId, int planeId, int airportToId, int airportFromId)
        {
            var flight = await _flightsContext.Flight.FindAsync(flightId);
            if (flight != null)
            {
                flight.Plane = await _flightsContext.Plane.FindAsync(planeId);
                //flight.AirportIdTo = airportToId;
                //flight.AirportIdFrom = airportFromId;
                await _flightsContext.SaveChangesAsync();
            }
        }

        public async Task CreateFlight(FlightDTO flightDTO)
        {
            var flight = new Flight
            {
                Name = flightDTO.Name,
                Destination = flightDTO.Destination,
                Departure = flightDTO.Departure,
                Arrival = flightDTO.Arrival,
                Status = flightDTO.Status,
                AirportToAirportId = (int)flightDTO.AirportToAirportId,
                AirportFromAirportId = (int)flightDTO.AirportFromAirportId,
                PlaneId = (int)flightDTO.PlaneId

            };

            _flightsContext.Flight.Add(flight);
            await _flightsContext.SaveChangesAsync();
        }


        public async Task DeleteFlight(int flightId)
        {
            var flight = await _flightsContext.Flight.FindAsync(flightId);
            if (flight != null)
            {
                _flightsContext.Flight.Remove(flight);
                await _flightsContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FlightDTO>> GetFlights()
        {
            var flights = await _flightsContext.Flight.ToListAsync();
            return flights.Select(f => new FlightDTO
            {
                Id = f.FlightId,
                Name = f.Name,
                Destination = f.Destination,
                Departure = f.Departure,
                Arrival = f.Arrival,
                Status = f.Status,
                AirportToAirportId = f.AirportToAirportId,
                AirportFromAirportId = f.AirportFromAirportId,
                PlaneId = f.PlaneId
            });
        }

        public async Task StartFlight(int flightId)
        {
            var flight = await _flightsContext.Flight.FindAsync(flightId);
            if (flight != null)
            {
                var airportFrom = await _flightsContext.Airport.FindAsync(flight.AirportFromAirportId);
                if (airportFrom != null)
                {
                    flight.Status = Status.Departed;
                    _flightsContext.Flight.Update(flight);

                    var plane = await _flightsContext.Plane.FindAsync(flight.PlaneId);
                    if (!airportFrom.Planes.IsNullOrEmpty() && airportFrom.Planes.Contains(plane))
                    {
                        airportFrom.Planes.Remove(plane);
                        _flightsContext.Airport.Update(airportFrom);
                    }
                    await _flightsContext.SaveChangesAsync();
                }
            }
        }

        public async Task FinishFlight(int flightId)
        {
            var flight = await _flightsContext.Flight.FindAsync(flightId);
            if (flight != null)
            {
                var airportTo = await _flightsContext.Airport.FindAsync(flight.AirportToAirportId);
                if (airportTo != null)
                {
                    flight.Status = Status.Arrived;
                    var plane = await _flightsContext.Plane.FindAsync(flight.PlaneId);

                    if (airportTo.Planes == null)
                        airportTo.Planes = new List<Plane>();

                    airportTo.Planes.Add(plane);

                    _flightsContext.Flight.Update(flight);
                    _flightsContext.Airport.Update(airportTo);
                    await _flightsContext.SaveChangesAsync();
                }
            }
        }


        public async Task MovePlaneToDestination(int flightId, int planeId, int airportId)
        {
            var flight = await _flightsContext.Flight.FindAsync(flightId);
            if (flight != null)
            {
                flight.Plane = await _flightsContext.Plane.FindAsync(planeId);
                //flight.AirportIdTo = airportId;
                await _flightsContext.SaveChangesAsync();
            }
        }

        public async Task SetStatus(int flightId, Status newStatus)
        {
            var flight = await _flightsContext.Flight.FindAsync(flightId);
            if (flight != null)
            {
                flight.Status = newStatus;
                await _flightsContext.SaveChangesAsync();
            }
        }
    }
}

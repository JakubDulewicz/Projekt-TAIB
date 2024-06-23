using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
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
                //FlightId = flightId,
                //Name = flightDTO.Name,
                //Destination = flightDTO.Destination,
                //Departure = flightDTO.Departure,
                //Arrival = flightDTO.Arrival,
                //Status = flightDTO.Status,


                Name = flightDTO.Name,
                Destination = flightDTO.Destination,
                Departure = flightDTO.Departure,
                Arrival = flightDTO.Arrival,
                Status = flightDTO.Status,
                AirportToAirportId = (int)flightDTO.AirportToAirportId,
                AirportFromAirportId = (int)flightDTO.AirportFromAirportId,
                PlaneId = (int)flightDTO.PlaneId
                //AirportFrom = flightDTO
                //AirportIdFrom = flightDTO.AirportFromId,
                //AirportIdTo = flightDTO.AirportToId,
                //PlaneId = flightDTO.PlaneId,
                //Destination = destination,
                //Departure = departure,
                //Arrival = arrival,
                //Status = status,
                //AirportIdTo = airportToId,
                //AirportIdFrom = airportFromId,
                //PlaneId = planeId,
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

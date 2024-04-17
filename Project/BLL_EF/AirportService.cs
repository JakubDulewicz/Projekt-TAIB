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
    public class AirportService : IAirportService
    {
        readonly FlightsContext _flightsContext;
        
        public AirportService(FlightsContext flightsContext)
        {
            _flightsContext = flightsContext;
        }



       public async Task AddAirport(int airportId, string name, string IATA, string country, string city, string address)
        {
            var airport = new Models.Airport()
            {
                Id = airportId,
                Name = name,
                IATA_CODE = IATA,
                Country = country,
                City = city,
                Address = address
            };
            _flightsContext.Airport.Add(airport);
            await _flightsContext.SaveChangesAsync();
        }

        private int GenerateUniqueId()
        {
            return new Random().Next(1, 100000);
        }

        public async Task RemoveAirport(AirportDTO airportId)
        {
            var deletedAirport = await _flightsContext.Airport.FindAsync(airportId);
            if (deletedAirport != null) 
            {
                _flightsContext.Airport.Remove(deletedAirport);
                await _flightsContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Unable to delete airport {airportId}");
            }
        }

        public async Task<IEnumerable<AirportDTO>> GetAllAirports()
        {
            var airports = await _flightsContext.Airport.ToListAsync();
            return airports.Select(airport => new AirportDTO
            {
                Id = airport.Id,
                Name = airport.Name,
                IATA_CODE = airport.IATA_CODE,
                Country = airport.Country,
                City = airport.City,
                Address = airport.Address
            });
        }

        public async Task AssignPlaneToAirport(int airportId, PlaneDTO plane)
        {
            var airport = await _flightsContext.Airport.FindAsync(airportId);
            if (airport != null)
            {
                /*if (airport.Planes == null)
                {
                    airport.Planes = new List<PlaneDTO>();
                }
                airport.Planes.Add(plane);
                await _flightsContext.SaveChangesAsync();*/
            }
            else
            {
                throw new ArgumentException($"Airport with ID {airportId} not found.");
            }
        
        }
    }
}

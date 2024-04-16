using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Models;

namespace BLL_EF
{
    public class AirportService : IAirportService
    {
        public List<AirportDTO> _airports { get; set; }
        Task IAirportService.AddAirport(int airportId, string name, string IATA, string country, string city, string address)
        {
            var airport = new AirportDTO()
            {
                Id = GenerateUniqueId(),
                Name = name,
                IATA_CODE = IATA,
                Country = country,
                City = city,
                Address = address
            };
            _airports.Add(airport);
            return Task.CompletedTask;
        }

        private int GenerateUniqueId()
        {
            return new Random().Next(1, 100000);
        }

        public Task RemoveAirport(AirportDTO airportId)
        {
            var deletedAirport = _airports.FirstOrDefault(airportId);
            if (deletedAirport != null) 
            {
                _airports.Remove(deletedAirport);
            }
            else
            {
                throw new ArgumentException($"Unable to delete airport {airportId}");
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<AirportDTO>> GetAllAirports()
        {
            IEnumerable<AirportDTO> Airports = _airports;

            return Task.FromResult(Airports);
        }

        public Task AssignPlaneToAirport(int airportId, PlaneDTO plane)
        {
            var airport = _airports.FirstOrDefault(a => a.Id == airportId);
            if (airport != null)
            {
                if (airport.Planes == null)
                {
                    airport.Planes = new List<PlaneDTO>();
                }
                airport.Planes.Add(plane);
            }
            else
            {
                throw new ArgumentException($"Airport with ID {airportId} not found.");
            }
            return Task.CompletedTask;
        }
    }
}

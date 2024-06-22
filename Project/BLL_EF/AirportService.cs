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
    public class AirportService : IAirportService
    {
        readonly FlightsContext _flightsContext;

        public AirportService(FlightsContext flightsContext)
        {
            _flightsContext = flightsContext;
        }



        public async Task AddAirport(AirportRequest request)
        {
            var airport = new Models.Airport()
            {
                //Id = airportId,
                Name = request.Name,
                IATA_CODE = request.IATA_CODE,
                Country = request.Country,
                City = request.City,
                Address = request.Address,

            };
            _flightsContext.Airport.Add(airport);

            //var p = request.Planes.ConvertAll(x => new Plane()
            //{
            //    Model = x.Model,
            //    PlaneId = x.Id,

            //});

            //_flightsContext.Plane.AddRangeAsync(p);
            await _flightsContext.SaveChangesAsync();
        }

        public async Task RemoveAirport(int airportId)
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
            var airports = await _flightsContext.Airport
                .Include(a => a.Planes)
                .ToListAsync();

            return airports.Select(airport => new AirportDTO
            {
                Id = airport.AirportId,
                Name = airport.Name,
                IATA_CODE = airport.IATA_CODE,
                Country = airport.Country,
                City = airport.City,
                Address = airport.Address,
                Planes = airport.Planes.Select(plane => new PlaneDTO
                {
                    Id = plane.PlaneId,
                    Model = plane.Model,
                    YearOfProduction = plane.YearOfProduction,
                    SeatCount = plane.SeatCount,
                    HasPrivateCabins = plane.HasPrivateCabins
                }).ToList()
            });
        }

        public async Task AssignPlaneToAirport(int airportId, int planeId)
        {
            var assignedAirport = await _flightsContext.Airport.Include(a => a.Planes).FirstOrDefaultAsync(a => a.AirportId == airportId);
            if (assignedAirport != null)
            {
                var assignedPlane = await _flightsContext.Plane.FindAsync(planeId);
                if (assignedPlane != null)
                {
                    // Inicjalizacja kolekcji jeśli jest null
                    if (assignedAirport.Planes == null)
                    {
                        assignedAirport.Planes = new List<Plane>();
                    }

                    // Dodaj samolot bezpośrednio do kolekcji
                    assignedAirport.Planes.Add(assignedPlane);

                    // Zapisz zmiany w kontekście
                    await _flightsContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException($"Plane with ID {planeId} not found or doesn't exist");
                }
            }
            else
            {
                throw new ArgumentException($"Airport with ID {airportId} not found.");
            }
        }
    }
}

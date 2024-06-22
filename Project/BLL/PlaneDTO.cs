using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PlaneDTO
    {
        public int Id { get; init; }
        public string Model { get; init; }
        public DateOnly YearOfProduction { get; init; }
        public int SeatCount { get; init; }
        public bool HasPrivateCabins { get; init; }
        public AirlineDTO Airlines { get; init; }
        public ICollection<FlightDTO> flight { get; set; }
        
    }

    public class PlaneRequest
    {
        public int Id { get; init; }
        public string Model { get; init; }
        public DateOnly YearOfProduction { get; init ; }
        public int SeatCount { get; init;}
        public bool HasPrivateCabins { get; init;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AirportDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string IATA_CODE { get; init; }
        public string Country { get; init; }
        public string City { get; init; }
        public string Address { get; init; }
        public ICollection<PlaneDTO> Planes { get; set; }
    }
}

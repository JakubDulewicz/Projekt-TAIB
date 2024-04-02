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
        public IEnumerable<PlaneDTO> Planes { get; init; }
        //Not sure if this is correct
        public int AirportIdTo { get; init; }
        public int AirportIdFrom { get; init; }

    }
}

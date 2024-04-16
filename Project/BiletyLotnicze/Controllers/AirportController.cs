using Microsoft.AspNetCore.Mvc;
using BLL_EF;
using BLL;

namespace BiletyLotnicze.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        readonly AirportService _airportService;
        public AirportController(AirportService flightService)
        {
            _airportService = flightService;
        }
        
        [HttpGet]
        public IEnumerable<AirportDTO> Get() 
        {
           // return this._airportService  
        }



    }
}

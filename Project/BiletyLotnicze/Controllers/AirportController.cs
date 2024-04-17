using Microsoft.AspNetCore.Mvc;
using BLL_EF;
using BLL;
using DAL;
using System.Linq;

namespace BiletyLotnicze.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : Controller
    {
        readonly FlightsContext _flightsContext;
        readonly AirportService _airportService;
/*        public AirportController(FlightsContext dbContext)
        {
            _flightsContext = dbContext;
        }*/

        public AirportController(AirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var airports = await _airportService.GetAllAirports();
                if (airports == null)
                {
                    return NotFound("Airports not found");
                }
                return Ok(airports);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request {ex.Message} ");
            }

        }

/*        [HttpPost]
        public Task AddAirport()
        {
            return Task.CompletedTask;
        }

        [HttpPut]
        public Task ModifyAirport() { return Task.CompletedTask; }

        [HttpDelete]
        public Task RemoveAirport() { return Task.CompletedTask; }
*/
    }
}

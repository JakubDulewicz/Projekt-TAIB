using BLL;
using BLL_EF;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace BiletyLotnicze.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : Controller
    {
        readonly FlightsContext _flightsContext;
        readonly FlightService _flightService;

        public FlightController (FlightService flightController)
        {
            _flightService = flightController;
        }

        [HttpGet("AllFlights")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var flights = await _flightService.GetFlights();
                if (flights == null)
                {
                    return NotFound("Flights not found");
                }
                return Ok(flights);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request {ex.Message} ");
            }

        }

    }
}

using BLL;
using BLL_EF;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Diagnostics.Metrics;
using System.Net;

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
        [HttpPost("AddFlight/{Name},{Destination},{Departure},{Arrival},{Status},{AirportIdTo},{AirportIdFrom},{PlaneId}")]
        public async Task<IActionResult> CreateFlight(string Name, string Destination, DateTime Departure, DateTime Arrival, Status Status, int AirportIdTo, int AirportIdFrom, int PlaneId)
        {
            try
            {
                await _flightService.CreateFlight(Name, Destination, Departure, Arrival, Status, AirportIdTo, AirportIdFrom, PlaneId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

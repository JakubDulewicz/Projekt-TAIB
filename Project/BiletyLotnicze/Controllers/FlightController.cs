using BLL;
using BLL_EF;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public FlightController(FlightService flightController)
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
        [HttpPost("AddFlight")]
        public async Task<IActionResult> CreateFlight(FlightDTO request)
        {
            try
            {
                await _flightService.CreateFlight(request);
                return Ok();
            }
            catch (DbUpdateException ex)
            {

                var innerException = ex.InnerException;
                Console.WriteLine(innerException?.Message);
                throw;
            }
        }
        
        [HttpPost("ChangeFlightStatus")]
        public async Task<IActionResult> ChangeFlightStatus(int id, Status status)
        {
            try
            {
                await _flightService.SetStatus(id,status);
                return Ok();
            }
            catch (DbUpdateException ex)
            {

                var innerException = ex.InnerException;
                Console.WriteLine(innerException?.Message);
                throw;
            }
        }

        [HttpPost("DepartFlight")]
        public async Task<IActionResult> StartFlight(int id)
        {
            try
            {
                await _flightService.StartFlight(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ArriveFlight")]
        public async Task<IActionResult> FinishedFlight(int id)
        {
            try
            {
                await _flightService.FinishFlight(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DeleteFlight")]
        public async Task<IActionResult> DeleteFlight(int request)
        {
            try
            {
                await _flightService.DeleteFlight(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}

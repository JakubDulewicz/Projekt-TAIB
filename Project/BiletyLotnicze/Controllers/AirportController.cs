using Microsoft.AspNetCore.Mvc;
using BLL_EF;
using BLL;
using DAL;
using System.Linq;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace BiletyLotnicze.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : Controller
    {
        readonly FlightsContext _flightsContext;
        readonly AirportService _airportService;


        public AirportController(AirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet("AllAirports")]
        public async Task<IActionResult> Get()
        {
            //throw new Exception("HDR");
                var airports = await _airportService.GetAllAirports();
                if (airports == null)
                {
                    return NotFound("Airports not found");
                }
                return Ok(airports);

        }

        [HttpPost("AddAirport")]
        public async Task<IActionResult> AddAirport(AirportRequest request)
        {
            try
            {
                await _airportService.AddAirport(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AssignPlaneToAirport")]
        public async Task<IActionResult> AssignPlane(int airportid, int planeid)
        {
            try
            {
                await _airportService.AssignPlaneToAirport(airportid, planeid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAirport")]
        public async Task<IActionResult> DeleteAirport(int id)
        {
            try
            {
                await _airportService.RemoveAirport(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        
    }
}

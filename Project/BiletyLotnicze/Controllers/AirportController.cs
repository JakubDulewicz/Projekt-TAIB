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
/*        public AirportController(FlightsContext dbContext)
        {
            _flightsContext = dbContext;
        }*/

        public AirportController(AirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet("AllAirports")]
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

      [HttpPost("AddAirport/{Name},{IATA_CODE},{Country},{City},{Address}")]
        public async Task<IActionResult> AddAirport(string Name, string IATA_CODE, string Country, string City, string Address)
        {
            try
            {
                await _airportService.AddAirport(Name, IATA_CODE, Country, City, Address);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAirport/{id}")]
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

using Microsoft.AspNetCore.Mvc;
using BLL_EF;
using BLL;

namespace BiletyLotnicze.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : Controller
    {
        readonly AirportService _airportService;
        public AirportController(AirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet]
        public Task<IEnumerable<AirportDTO>> GetAllAirports()
        {
            return this._airportService.GetAllAirports();
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

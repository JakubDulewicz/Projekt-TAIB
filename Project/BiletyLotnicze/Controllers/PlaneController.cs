using Microsoft.AspNetCore.Mvc;
using BLL_EF;
using BLL;
using DAL;
using System.Linq;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;

namespace BiletyLotnicze.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaneController : Controller
    {
        readonly FlightsContext _flightsContext;
        readonly PlaneService _planeService;

        public PlaneController(PlaneService planeService)
        {
            _planeService = planeService;
        }

        [HttpGet("AllPlanes")]
        public async Task<IActionResult> Get()
        {
            var planes = await _planeService.GetAllPlanes();
            if (planes == null)
            {
                return NotFound("Plane not found");
            }
            return Ok(planes);
        }

        [HttpPost("AddPlane")]
        public async Task<IActionResult> AddPlane(PlaneRequest request)
        {
            try
            {
                await _planeService.AddPlane(request);
                return Ok();
            }
            catch (DbUpdateException ex)
            {

                var innerException = ex.InnerException;
                Console.WriteLine(innerException?.Message);
                throw;
            }

        }

    }
}

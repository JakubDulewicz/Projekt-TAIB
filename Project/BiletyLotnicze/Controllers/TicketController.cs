using BLL;
using BLL_EF;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace BiletyLotnicze.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : Controller
    {
        readonly FlightsContext _flightsContext;
        readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("CreateTicket")]
        public async Task<IActionResult> AddAirport(TicketDTO ticketDTO)
        {
            try
            {
                await _ticketService.CreateTicket(ticketDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using BLL;
using BLL_EF;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet("AllTickets")]
        public async Task<IActionResult> Get()
        {
            //throw new Exception("HDR");
            var tickets = await _ticketService.GetTickets();
            if (tickets == null)
            {
                return NotFound("Ticket not found");
            }
            return Ok(tickets);

        }

        [HttpPost("CreateTicket")]
        public async Task<IActionResult> AddTicket(TicketDTO ticketDTO)
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

        //[Authorize]
        [HttpPost("BuyTicket")]
        public async Task<IActionResult> BuyTicket(TicketRequest ticketRequest)
        {
            try
            {
               // var userId = int.Parse(User.FindFirst(ClaimTypes.Name)?.Value);
                await _ticketService.BuyTicket(ticketRequest, ticketRequest.UserId);
                return Ok("Ticket purchased successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }


    }
}

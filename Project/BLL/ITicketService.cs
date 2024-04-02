using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ITicketService
    {
        Task AddTicket(TicketDTO ticketId, FlightDTO flightId);
        Task DeleteTicket(TicketDTO ticketId);
        Task<IEnumerable<TicketDTO>> GetTickets(TicketDTO Ticket);
    }
}

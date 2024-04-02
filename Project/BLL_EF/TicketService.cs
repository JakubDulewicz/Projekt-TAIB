using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL_EF
{
    public class TicketService : ITicketService
    {

        public Task AddTicket(TicketDTO ticketId, FlightDTO flightId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTicket(TicketDTO ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TicketDTO>> GetTickets(TicketDTO Ticket) 
        {
            throw new NotImplementedException();
        }
    }
}

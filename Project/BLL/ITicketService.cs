using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ITicketService
    {
        Task CreateTicket(string seat, Class flightClass,double price, int flightId, int airlineId);
        
        Task AsignTicketToUser(int ticketId, int userId);
        Task DeleteTicket(TicketDTO ticketId);
        Task<IEnumerable<TicketDTO>> GetTickets();
    }
}

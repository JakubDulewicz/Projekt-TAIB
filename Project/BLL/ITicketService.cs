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
        Task CreateTicket(TicketDTO ticketDTO);
        Task AsignTicketToUser(int ticketId, int userId);
        Task DeleteTicket(int ticketId);
        Task<IEnumerable<TicketDTO>> GetTickets();
    }
}

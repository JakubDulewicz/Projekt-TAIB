using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ITicketService
    {
        Task AddTicket(int ticketId, int flightId);
        Task DeleteTicket(int ticketId);
        Task<int> GetTicketCount(int ticketId);
    }
}

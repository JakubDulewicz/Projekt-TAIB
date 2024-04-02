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
        public Task AddTicket(int ticketId, int flightId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTicket(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTicketCount(int ticketId)
        {
            throw new NotImplementedException();
        }
    }
}

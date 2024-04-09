using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Models;

namespace BLL_EF
{
    public class TicketService : ITicketService
    {
        readonly IFlightService _flightService;



        public List<TicketDTO> _tickets{ get; set; }

        Task ITicketService.CreateTicket(string seat, Class flightClass, double price, int flightId, int airlineId)
        {
            var ticket = new TicketDTO()
            {
                Id = GenerateUniqueId(),
                Seat = seat,
                Class = flightClass,
                Price = price,
                FlightId = flightId,
                AirlineId = airlineId
            };
            if(price <= 0)
            {
                throw new ArgumentException("Price must be greater than 0");
            }
            else
            {
                _tickets.Add(ticket);
                return Task.CompletedTask;
            }
            
        }
        private int GenerateUniqueId()
        {
            return new Random().Next(1, 100000);
        }

        public Task DeleteTicket(TicketDTO ticketId)
        {
            var deletedTicket = _tickets.FirstOrDefault(ticketId);
            if(deletedTicket != null)
            {
                _tickets.Remove(deletedTicket);
            }
            else
            {
                throw new ArgumentException($"Unable to delete ticket {ticketId}");
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<TicketDTO>> GetTickets()
        {
            IEnumerable<TicketDTO> tickets = _tickets;

            return Task.FromResult(tickets);
        }

        public Task AsignTicketToUser(int ticketId, int userId)
        {
            var ticket = _tickets.FirstOrDefault(t => t.UserId == userId && t.Id == ticketId);
            if (ticket != null)
            {
                ticket.UserId = userId;
            }
            else
            {
                throw new InvalidOperationException("Ticket not fount");
            }
            return Task.CompletedTask;
        }
    }
}

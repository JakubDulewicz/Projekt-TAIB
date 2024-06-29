using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BLL_EF
{
    public class TicketService : ITicketService
    {
        readonly FlightsContext _flightsContext;

        public TicketService(FlightsContext flightsContext)
        {
            _flightsContext = flightsContext;
        }
        public async Task CreateTicket(TicketDTO ticketDTO)
        {
            var user = await _flightsContext.User.FindAsync(ticketDTO.UserId);
            var flight = await _flightsContext.Flight.FindAsync(ticketDTO.FlightId);
            var airline = await _flightsContext.Airline.FindAsync(ticketDTO.AirlineId);

            if (user == null || flight == null || airline == null)
            {
                throw new ArgumentException("Invalid user, flight, or airline ID.");
            }

            var ticket = new Ticket()
            {
                TicketId = ticketDTO.Id,
                Seat = ticketDTO.Seat,
                Class = ticketDTO.Class,
                Price = ticketDTO.Price,
                User = user,
                Flight = flight,
                Airlines = airline
            };

            _flightsContext.Ticket.Add(ticket);
            await _flightsContext.SaveChangesAsync();
        }

        public Task AsignTicketToUser(int ticketId, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTicket(int ticketId)
        {
            var deletedTicket = await _flightsContext.Ticket.FindAsync(ticketId);
            if (deletedTicket != null)
            {
                _flightsContext.Ticket.Remove(deletedTicket);
                await _flightsContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Unable to delete airport {ticketId}");
            }
        }

        public async Task<IEnumerable<TicketDTO>> GetTickets()
        {
            var tickets = await _flightsContext.Ticket
            .Include(t => t.User)
            .Include(t => t.Flight)
            .Include(t => t.Airlines)
            .ToListAsync();
            return tickets.Select(t => new TicketDTO
            {
                Id = t.TicketId,
                Seat = t.Seat,
                Class = t.Class,
                Price = t.Price,
                UserId = t.User.UserId,
                FlightId = t.Flight.FlightId,
                AirlineId = t.Airlines.AirlineId,
            });
        }

        public async Task BuyTicket(TicketRequest ticketRequest, int userId)
        {
            var user = await _flightsContext.User.FindAsync(userId);
            if (user == null)
                throw new Exception("Invalid user");

            var flight = await _flightsContext.Flight.FindAsync(ticketRequest.FlightId);
            if (flight == null)
                throw new Exception("Invalid flight");

            var airline = await _flightsContext.Airline.FindAsync(ticketRequest.AirlineId);
            if (airline == null)
                throw new Exception("Invalid airline");


            var ticket = new Ticket
            {
                Seat = ticketRequest.Seat,
                Class = ticketRequest.Class,
                Price = ticketRequest.Price,
                User = user,
                Flight = flight,
                Airlines = airline

            };

            _flightsContext.Ticket.Add(ticket);
            await _flightsContext.SaveChangesAsync();

        }
    }
}

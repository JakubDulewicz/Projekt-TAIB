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
            if(deletedTicket != null)
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
            var tickets = await _flightsContext.Ticket.ToListAsync();
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

        //Task ITicketService.CreateTicket(string seat, Class flightClass, double price, int flightId, int airlineId)
        //{
        //    var ticket = new TicketDTO()
        //    {
        //        Id = GenerateUniqueId(),
        //        Seat = seat,
        //        Class = flightClass,
        //        Price = price,
        //        FlightId = flightId,
        //        AirlineId = airlineId
        //    };
        //    if(price <= 0)
        //    {
        //        throw new ArgumentException("Price must be greater than 0");
        //    }
        //    else
        //    {
        //        _tickets.Add(ticket);
        //        return Task.CompletedTask;
        //    }

        //}
        //private int GenerateUniqueId()
        //{
        //    return new Random().Next(1, 100000);
        //}

        //public Task DeleteTicket(TicketDTO ticketId)
        //{
        //    var deletedTicket = _tickets.FirstOrDefault(ticketId);
        //    if(deletedTicket != null)
        //    {
        //        _tickets.Remove(deletedTicket);
        //    }
        //    else
        //    {
        //        throw new ArgumentException($"Unable to delete ticket {ticketId}");
        //    }
        //    return Task.CompletedTask;
        //}

        //public Task<IEnumerable<TicketDTO>> GetTickets()
        //{
        //    IEnumerable<TicketDTO> tickets = _tickets;

        //    return Task.FromResult(tickets);
        //}

        //public Task AsignTicketToUser(int ticketId, int userId)
        //{
        //    var ticket = _tickets.FirstOrDefault(t => t.UserId == userId && t.Id == ticketId);
        //    if (ticket != null)
        //    {
        //        ticket.UserId = userId;
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Ticket not found");
        //    }
        //    return Task.CompletedTask;
        //}
    }
}

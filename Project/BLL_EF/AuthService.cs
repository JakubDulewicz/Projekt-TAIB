﻿using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class AuthService : IAuthService
    {
        private readonly FlightsContext _context;

        public AuthService(FlightsContext context)
        {
            _context = context;
        }

        public async Task<string> Register(UserDTO userDto)
        {
            var user = new Users
            {
                Name = userDto.Name,
                Pesel = userDto.Pesel,
                Email = userDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                Date = userDto.Date,
                Phone = userDto.Phone,
                Roles = userDto.Roles
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return "User registered successfully";
        }

        public async Task<string> Login(LoginRequest request)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ThisIsA32ByteLongSecureKeyForJWTAuth");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _context.User
        .Include(u => u.Tickets)
            .ThenInclude(t => t.Flight)
        .Include(u => u.Tickets)
            .ThenInclude(t => t.Airlines)
        .ToListAsync();

            var userDTOs = users.Select(u => new UserDTO
            {
                Id = u.UserId,
                Name = u.Name,
                Pesel = u.Pesel,
                Email = u.Email,
                Password = u.Password,
                Date = u.Date,
                Phone = u.Phone,
                Roles = u.Roles,
                Tickets = u.Tickets.Select(t => new TicketDTO
                {
                    Id = t.TicketId,
                    Seat = t.Seat,
                    Class = t.Class,
                    Price = t.Price,
                    UserId = t.User.UserId,
                    FlightId = t.Flight.FlightId,
                    AirlineId = t.Airlines.AirlineId,
                })
            }).ToList();

            return userDTOs;
        }
    }
}

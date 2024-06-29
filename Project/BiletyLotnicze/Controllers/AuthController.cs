using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using BLL;
using DAL;
using Microsoft.AspNetCore.Identity.Data;
using Models;
using Azure.Core;
using BLL_EF;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly FlightsContext _context;
    readonly AuthService _authService;

    public AuthController(AuthService authController)
    {
        _authService = authController;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDTO userDto)
    {
        try
        {
            await _authService.Register(userDto);
            return Ok();
        }
        catch (DbUpdateException ex)
        {

            var innerException = ex.InnerException;
            Console.WriteLine(innerException?.Message);
            throw;
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            await _authService.Login(request);
            return Ok();
        }
        catch (DbUpdateException ex)
        {

            var innerException = ex.InnerException;
            Console.WriteLine(innerException?.Message);
            throw;
        }
    }
    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var flights = await _authService.GetAllUsers();
            if (flights == null)
            {
                return NotFound("Flights not found");
            }
            return Ok(flights);
        }
        catch (Exception ex)
        {
            return BadRequest($"Bad Request {ex.Message} ");
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;


namespace Todo.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AuthController(DataContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(User newUser)
        {

            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                return BadRequest("email is already registered");
            }
            newUser.Password = _passwordHasher.HashPassword(newUser, newUser.Password);

            try
            {
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error");
            }



        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginRequest.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(new { message = "login successful", user = user });
        }
    }
}

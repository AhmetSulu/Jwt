using Jwt.Data;
using Jwt.Dtos;
using Jwt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtDbContext _jwtContext;
        private readonly IConfiguration _configuration;

        public AuthController(JwtDbContext context, IConfiguration configuration)
        {
            _jwtContext = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data submitted.");
            }

            
            var existingUser = await _jwtContext.Users.FirstOrDefaultAsync(u => u.Email == userRegisterDto.Email);
            if (existingUser != null)
            {
                return BadRequest("Email is already in use.");
            }

            var user = new User { Email = userRegisterDto.Email, Password = userRegisterDto.Password };

            _jwtContext.Users.Add(user);
            await _jwtContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Register), new { id = user.Id }, "User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data submitted.");
            }

            var user = await _jwtContext.Users.FirstOrDefaultAsync(u => u.Email == userLoginDto.Email);
            if (user == null)
            {
                return BadRequest("Invalid email or password.");
            }

            if (user.Password != userLoginDto.Password)
            {
                return BadRequest("Invalid email or password.");
            }


            var token = Helper.CreateJwtToken(user.Email, _configuration["Jwt:Key"], _configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], 60);

            return Ok(new { Token = token, Message = "Login successful." });
        }
    }
}

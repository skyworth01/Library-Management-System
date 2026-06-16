using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginDto dto)
        {
            var token =
                await _authService.LoginAsync(dto);

            if (token == null)
                return Unauthorized();

            return Ok(new
            {
                Token = token
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDto>> Register(
        RegisterUserDto dto)
        {
            var user = await _authService.RegisterAsync(dto);

            return CreatedAtAction(
                nameof(Register),
                new { id = user },
                user);
        }
    }
}

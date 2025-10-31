using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;
using Backend.Enums;
using Backend.DTOs;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = new User
            {
                FullName = "John Doe",
                Address = "123 Main Street",
                Role = Role.Librarian,
                Phone = "9876543210",
                ExternalId = $"EXT-{id}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] CreateUserDto user)
        {
            var response = _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetById), new { id = response.UserId }, response);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var response = _userService.GetAllUsers();
            return Ok(response);
        }

    }
}
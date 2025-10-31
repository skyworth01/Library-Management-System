using Backend.DTOs;
using Backend.Models;

namespace Backend.Services
{
    public interface IUserService
    {
        UserResponseDto CreateUser(CreateUserDto user);
        IEnumerable<User> GetAllUsers();
    }
}
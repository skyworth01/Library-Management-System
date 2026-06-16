using Backend.DTOs;

namespace Backend.Services
{
    public interface IUserService
    {
        IEnumerable<UserResponseDto> GetAllUsers();

        Task<UserResponseDto?> GetUser(int id);
    }
}
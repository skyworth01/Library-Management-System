
using Backend.DTOs;

namespace Backend.Services
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginDto dto);

        Task<UserResponseDto> RegisterAsync(
        RegisterUserDto dto);
    }

}
using AutoMapper;
using Backend.Models;
using Backend.DTOs;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository repository,IJwtService jwtService,IMapper mapper)
        {
            _userRepository = repository;
            _jwtService = jwtService;
            _mapper = mapper;
        }
        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetAll().Where(x => x.EmailId == dto.EmailId).FirstOrDefaultAsync();

            if (user == null)
                return null;

            var isPasswordValid =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.PasswordHash);

            if (!isPasswordValid)
                return null;

            return _jwtService.GenerateToken(user);
        }

        public async Task<UserResponseDto> RegisterAsync(
        RegisterUserDto dto)
        {
            var existingUser =
                await _userRepository
                    .GetByEmailIdAsync(dto.EmailId);

            if (existingUser != null)
            {
                throw new Exception(
                    "Username already exists.");
            }

            var user = _mapper.Map<User>(dto);

            user.PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(
                    dto.Password);

            user.Role = Enums.Role.User;
            user.CreatedAt = new DateTime();
            user.UpdatedAt = new DateTime();

            _userRepository.Add(user);
            await _userRepository.SaveAsync();

            return _mapper.Map<UserResponseDto>(user);
        }
    }
}

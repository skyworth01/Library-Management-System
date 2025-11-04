using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository,IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }
        public UserResponseDto CreateUser(CreateUserDto user)
        {
            var userEntity = _mapper.Map<User>(user);
            _userRepository.Add(userEntity);
            _userRepository.Save();

            return _mapper.Map<UserResponseDto>(userEntity);
        }

        public IEnumerable<UserResponseDto> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }

        public UserResponseDto? GetUser(int id)
        {
            var user = _userRepository.GetById(id);
            return user == null ? null : _mapper.Map<UserResponseDto>(user);
        }

    }
    
}
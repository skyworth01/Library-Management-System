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

        public IEnumerable<User> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return users;
        }

    }
    
}
using Backend.Models;

namespace Backend.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        void Add(User user);
        Task SaveAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailIdAsync(string emailId);
    }
}
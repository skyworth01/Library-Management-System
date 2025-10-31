using Backend.Models;

namespace Backend.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        void Add(User user);
        void Save();
    }
}
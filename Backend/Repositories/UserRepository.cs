using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll() => _context.Users.AsNoTracking().AsQueryable();

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public async Task<User?> GetByEmailIdAsync(string emailId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(
                    x => x.EmailId == emailId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
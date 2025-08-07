using Forum.Application.Contracts.Persistence;
using Forum.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Forum.Persistence.Repositories;

public class UserRepository : GenericRepository<User>,  IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<User?> GetByUsernameAsync(string username)
    {  
        return await _context.Users
            .Include(u => u.Profile)
            .SingleOrDefaultAsync(u => u.Credentials.Username == username);
    }

    public async Task<IEnumerable<User>> GetByEmailAsync(string email)
    {
        return await _context.Users
            .Include(u => u.Profile)
            .Where(u => u.Credentials.Email == email)
            .ToListAsync();
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.UserCredentials
            .AnyAsync(u => u.Email == email);
    }

    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _context.UserCredentials
            .AnyAsync(u => u.Username == username);
    }
}
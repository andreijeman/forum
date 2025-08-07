using Forum.Application.Contracts.Persistence;
using Forum.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Forum.Persistence.Repositories;

public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<UserRole?> GetByNameAsync(string name)
    {
        return await _context.UserRoles
            .SingleOrDefaultAsync(r => r.Name == name);
    }
}
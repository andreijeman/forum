using Forum.Domain.Entities.User;

namespace Forum.Application.Contracts.Persistence;

public interface IUserRoleRepository :  IGenericRepository<UserRole>
{
    Task<UserRole?> GetByNameAsync(string name);
}
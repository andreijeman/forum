using Forum.Domain.Entities.User;

namespace Forum.Application.Contracts.Infrastructure;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
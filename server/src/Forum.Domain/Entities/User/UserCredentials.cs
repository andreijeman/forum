namespace Forum.Domain.Entities.User;

public class UserCredentials
{
    public Guid UserId { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
}
namespace Forum.Domain.Entities.User;

public class User
{
    public Guid Id { get; set; }
    public required UserCredentials Credentials { get; set; }
    public required UserProfile Profile { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = [];
}
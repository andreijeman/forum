namespace Forum.Domain.Entities.User;

public class UserProfile
{
    public Guid UserId { get; set; }
    public required string Username { get; set; }
    public  string AvatarUrl { get; set; }
}
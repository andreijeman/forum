namespace Forum.Domain.Entities.User;

public class UserProfile
{
    public Guid UserId { get; set; }
    public string? AvatarUrl { get; set; }
}
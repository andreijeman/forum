using Forum.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Persistence.Configurations;

public class UserCredentialsConfig : IEntityTypeConfiguration<UserCredentials>
{
    public void Configure(EntityTypeBuilder<UserCredentials> builder)
    {
        builder.HasKey(e => e.UserId);
        builder.HasIndex(e => e.Email).IsUnique();
        builder.HasIndex(e => e.Username).IsUnique();
    }
}
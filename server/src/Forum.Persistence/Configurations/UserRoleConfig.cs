using Forum.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Persistence.Configurations;

public class UserRoleConfig :  IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasIndex(r => r.Name).IsUnique();
        builder.HasData(new UserRole { Id = 1, Name = "user" });
    }
}
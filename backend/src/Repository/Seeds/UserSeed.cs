using AutoServiceTracking.Shared.Security.Encryption;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds;

internal class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        List<User> users = new();
        User adminUser =
            new()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin Kaçmaz",
                Email = "admin@admin.com",
                Status = true,
                Password = "1234",
            };
        users.Add(adminUser);

        builder.HasData(users.ToArray());
    }
}

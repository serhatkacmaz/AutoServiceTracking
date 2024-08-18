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
                Password = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220",
                CreatedDate = DateTime.Now,
            };
        users.Add(adminUser);

        builder.HasData(users.ToArray());
    }
}

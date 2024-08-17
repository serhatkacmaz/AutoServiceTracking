using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoServiceTracking.Shared.Security.Encryption;

namespace Repository.Seeds;

internal class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        List<User> users = new();

        PasswordHelper.CreatePasswordHash(
            password: "Test123",
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        User adminUser =
            new()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin Kaçmaz",
                Email = "admin@admin.com",
                Status = true,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        users.Add(adminUser);

        builder.HasData(users.ToArray());
    }
}

using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class RefreshTokenConfiguration : BaseEntityTypeConfiguration<RefreshToken, int>
{
    public override void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        base.Configure(builder);

        builder.Property(rt => rt.UserId).IsRequired();
        builder.Property(rt => rt.Code).IsRequired().HasMaxLength(200);

        builder.HasOne(rt => rt.User);
    }
}
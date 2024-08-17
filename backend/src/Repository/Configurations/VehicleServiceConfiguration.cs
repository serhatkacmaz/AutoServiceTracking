using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class VehicleServiceConfiguration : GrandEntityTypeConfiguration<ServiceEntry, int>
{
    public override void Configure(EntityTypeBuilder<ServiceEntry> builder)
    {
        base.Configure(builder);

        builder.Property(vs => vs.LicensePlate)
               .IsRequired()
               .HasMaxLength(10);

        // Index
        builder.HasIndex(vs => vs.LicensePlate)
            .HasDatabaseName("IX_ServiceEntry_LicensePlate");

        builder.Property(vs => vs.BrandName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(vs => vs.ModelName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(vs => vs.Kilometers)
               .IsRequired();

        builder.Property(vs => vs.ServiceDate)
               .IsRequired();

        builder.Property(vs => vs.ServiceNotes)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);
    }
}

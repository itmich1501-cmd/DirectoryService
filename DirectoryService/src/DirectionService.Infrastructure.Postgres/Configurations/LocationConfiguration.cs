using DirectionService.Domain.Departaments;
using DirectionService.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectionService.Infrastructure.Postgres.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");

        builder.Property(v => v.Id)
            .HasConversion(v => v.Value, v => new LocationId(v))
            .HasColumnName("id");

        builder.HasKey(v => v.Id).HasName("pk_locations");

        builder.Property(v => v.Name)
            .HasConversion(v => v.Name, v => LocationName.Create(v).Value)
            .HasColumnName("name")
            .IsRequired();

        builder.ComplexProperty(v => v.Address, v =>
        {
            v.Property(v => v.Country)
                .HasColumnName("country")
                .IsRequired();

            v.Property(v => v.City)
                .HasColumnName("city")
                .IsRequired();

            v.Property(v => v.Street)
                .HasColumnName("street")
                .IsRequired();

            v.Property(v => v.HouseNumber)
                .HasColumnName("house_number")
                .IsRequired(false);

            v.Property(v => v.PostalCode)
                .HasColumnName("postal_code")
                .IsRequired(false);
        });

        builder.Property(v => v.Timezone)
            .HasConversion(v => v.Value, v => LocationTimezone.Create(v).Value)
            .HasColumnName("timezone")
            .IsRequired();

        builder.Property(v => v.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(v => v.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(v => v.UpdatedAt)
            .HasColumnName("update_at")
            .IsRequired();
    }
}
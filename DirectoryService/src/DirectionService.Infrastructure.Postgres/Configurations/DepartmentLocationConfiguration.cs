using DirectionService.Domain.Departaments;
using DirectionService.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.Extensions.Logging.Abstractions;

namespace DirectionService.Infrastructure.Postgres.Configurations;

public class DepartmentLocationConfiguration: IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("department_locations");

        builder.HasKey(v => v.Id).HasName("pk_department_locations");

        builder.Property(v => v.Id)
            .HasConversion(v => v.Value, v => new DepartmentLocationId(v))
            .HasColumnName("id");

        builder.Property(v => v.DepartmentId)
            .HasConversion(v => v.Value, v => new DepartmentId(v))
            .HasColumnName("department_id")
            .IsRequired();

        builder.Property(v => v.LocationId)
            .HasConversion(v => v.Value, v => new LocationId(v))
            .HasColumnName("location_id")
            .IsRequired();

        builder.HasIndex(v => new { v.DepartmentId, v.LocationId })
            .HasDatabaseName("uk_department_locations_department_id_location_id")
            .IsUnique();

        builder.HasOne<Departament>()
            .WithMany(v => v.Locations)
            .HasForeignKey(v => v.DepartmentId)
            .HasConstraintName("fk_department_locations_department_id");

        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(v => v.LocationId)
            .HasConstraintName("fk_department_locations_location_id");

    }
}
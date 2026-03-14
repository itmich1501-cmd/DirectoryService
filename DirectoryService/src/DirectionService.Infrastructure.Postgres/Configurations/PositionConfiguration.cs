using DirectionService.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace DirectionService.Infrastructure.Postgres.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");

        builder.HasKey(v => v.Id).HasName("pk_positions");

        builder.Property(v => v.Id)
            .HasConversion(v => v.Value, v => new PositionId(v))
            .HasColumnName("id");

        builder.Property(v => v.Name)
            .HasColumnName("name")
            .IsRequired();

        builder.Property(v => v.Description)
            .HasColumnName("description")
            .IsRequired(false);

        builder.Property(v => v.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(v => v.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired(true);

        builder.Property(v => v.UpdatedAt)
            .HasColumnName("update_at")
            .IsRequired(false);
    }
}
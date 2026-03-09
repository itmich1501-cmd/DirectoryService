using DirectionService.Domain.Departaments;
using DirectionService.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectionService.Infrastructure.Postgres.Configurations;

public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("department_positions");

        builder.HasKey(v => v.Id).HasName("pk_department_positions");

        builder.Property(v => v.Id)
            .HasConversion(v => v.Value, v => new DepartmentPositionId(v))
            .HasColumnName("id");

        builder.Property(v => v.DepartmentId)
            .HasConversion(v => v.Value, v => new DepartmentId(v))
            .HasColumnName("department_id")
            .IsRequired();

        builder.Property(v => v.PositionId)
            .HasConversion(v => v.Value, v => new PositionId(v))
            .HasColumnName("position_id")
            .IsRequired();

        builder.HasIndex(v => new { v.DepartmentId, v.PositionId })
            .HasDatabaseName("uk_department_positions_department_id_position_id")
            .IsUnique();

        builder.HasOne<Departament>()
            .WithMany(v => v.Positions)
            .HasForeignKey(v => v.DepartmentId)
            .HasConstraintName("fk_department_positions_department_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Position>()
            .WithMany()
            .HasForeignKey(v => v.PositionId)
            .HasConstraintName("fk_department_positions_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(v => v.PositionId)
            .HasDatabaseName("fk_department_positions_position_id")
            .IsUnique();
    }
}
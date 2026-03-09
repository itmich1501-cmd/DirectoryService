using DirectionService.Domain.Departaments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared;

namespace DirectionService.Infrastructure.Postgres.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Departament>
{
    public void Configure(EntityTypeBuilder<Departament> builder)
    {
        builder.ToTable("departaments");

        builder.HasKey(v => v.Id).HasName("pk_departaments");

        builder.Property(v => v.Id)
            .HasConversion(v => v.Value, v => new DepartmentId(v))
            .HasColumnName("id");

        builder.Property(v => v.Name)
            .HasConversion(
                x => x.Name,
                x => DepartmentName.FromDatabase(x))
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(v => v.Identifier)
            .HasColumnName("identifier")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(v => v.ParentId)
            .HasConversion(v => v.Value, v => new DepartmentId(v))
            .HasColumnName("parent_id")
            .IsRequired(false);

        builder.Property(v => v.Path)
            .HasConversion(
                v => v.Path,
                v => DepartmentPath.FromDatabase(v))
            .HasColumnName("path")
            .IsRequired(false);

        builder.Property(v => v.Depth)
            .HasColumnName("depth");

        builder.Property(v => v.IsActive)
            .HasColumnName("is_active");

        builder.Property(v => v.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(v => v.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}
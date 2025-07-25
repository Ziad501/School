using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentConfigurations;

internal class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasMany(x => x.Teachers)
            .WithOne(t => t.Department)
            .HasForeignKey(t => t.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.DepartmentCourses)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Students)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Department
            {
                Id = SeedingIds.CsDeptId,
                Name = "Computer Science",
                Code = "CS",
                HeadOfDepartmentId = SeedingIds.Teacher1Id
            },
            new Department
            {
                Id = SeedingIds.EeDeptId,
                Name = "Electrical Engineering",
                Code = "EE",
                HeadOfDepartmentId = SeedingIds.Teacher2Id
            }
        );
    }
}
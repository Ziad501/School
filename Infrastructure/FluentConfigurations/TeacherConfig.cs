using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentConfigurations
{
    internal class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.Phone)
                .HasMaxLength(50);

            builder.HasOne(t => t.Department)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Teacher
                {
                    Id = SeedingIds.Teacher1Id,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@university.edu",
                    Phone = "555-0201",
                    DepartmentId = SeedingIds.CsDeptId
                },
                new Teacher
                {
                    Id = SeedingIds.Teacher2Id,
                    FirstName = "Sarah",
                    LastName = "Johnson",
                    Email = "sarah.johnson@university.edu",
                    Phone = "555-0202",
                    DepartmentId = SeedingIds.EeDeptId
                },
                new Teacher
                {
                    Id = SeedingIds.Teacher3Id,
                    FirstName = "Michael",
                    LastName = "Brown",
                    Email = "michael.brown@university.edu",
                    Phone = "555-0203",
                    DepartmentId = SeedingIds.CsDeptId
                }
            );
        }
    }
}
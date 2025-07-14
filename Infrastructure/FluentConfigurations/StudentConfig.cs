using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentConfigurations
{
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Student
                {
                    Id = SeedingIds.Student1Id,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@student.edu",
                    Address = "123 Tech Way",
                    Phone = "555-0101",
                    DepartmentId = SeedingIds.CsDeptId,
                    DateOfBirth = new DateTime(2000, 5, 15),
                    EnrollmentDate = DateTime.UtcNow.AddYears(-1)
                },
                new Student
                {
                    Id = SeedingIds.Student2Id,
                    FirstName = "Bob",
                    LastName = "Williams",
                    Email = "bob.williams@student.edu",
                    Address = "456 Code Lane",
                    Phone = "555-0102",
                    DepartmentId = SeedingIds.CsDeptId,
                    DateOfBirth = new DateTime(2001, 3, 22),
                    EnrollmentDate = DateTime.UtcNow.AddYears(-1)
                },
                new Student
                {
                    Id = SeedingIds.Student3Id,
                    FirstName = "Charlie",
                    LastName = "Brown",
                    Email = "charlie.brown@student.edu",
                    Address = "789 Logic Blvd",
                    Phone = "555-0103",
                    DepartmentId = SeedingIds.EeDeptId,
                    DateOfBirth = new DateTime(1999, 11, 8),
                    EnrollmentDate = DateTime.UtcNow.AddMonths(-6)
                },
                new Student
                {
                    Id = SeedingIds.Student4Id,
                    FirstName = "Diana",
                    LastName = "Miller",
                    Email = "diana.miller@student.edu",
                    Address = "101 Algorithm Ave",
                    Phone = "555-0104",
                    DepartmentId = SeedingIds.CsDeptId,
                    DateOfBirth = new DateTime(2002, 1, 30),
                    EnrollmentDate = DateTime.UtcNow.AddMonths(-6)
                },
                new Student
                {
                    Id = SeedingIds.Student5Id,
                    FirstName = "Eve",
                    LastName = "Davis",
                    Email = "eve.davis@student.edu",
                    Address = "212 Circuit Cr",
                    Phone = "555-0105",
                    DepartmentId = SeedingIds.EeDeptId,
                    DateOfBirth = new DateTime(2000, 7, 12),
                    EnrollmentDate = DateTime.UtcNow.AddYears(-2)
                }
            );
        }
    }
}
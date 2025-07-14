using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentConfigurations
{
    internal class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Description).HasMaxLength(1000);

            builder.HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.StudentCourses)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.DepartmentCourses)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
               new Course
               {
                   Id = SeedingIds.DataStructId,
                   Name = "Data Structures",
                   Code = "CS201",
                   Description = "Fundamental data structures and algorithms",
                   StartDate = DateTime.UtcNow.AddMonths(-1),
                   EndDate = DateTime.UtcNow.AddMonths(3),
                   CreditHours = 4,
                   TeacherId = SeedingIds.Teacher1Id
               },
               new Course
               {
                   Id = SeedingIds.AlgorithmsId,
                   Name = "Analysis of Algorithms",
                   Code = "CS301",
                   Description = "Advanced algorithm design and analysis",
                   StartDate = DateTime.UtcNow.AddMonths(-1),
                   EndDate = DateTime.UtcNow.AddMonths(3),
                   CreditHours = 3,
                   TeacherId = SeedingIds.Teacher1Id
               },
               new Course
               {
                   Id = SeedingIds.DbSystemsId,
                   Name = "Database Systems",
                   Code = "CS202",
                   Description = "Relational database design and implementation",
                   StartDate = DateTime.UtcNow.AddMonths(-1),
                   EndDate = DateTime.UtcNow.AddMonths(3),
                   CreditHours = 3,
                   TeacherId = SeedingIds.Teacher3Id
               },
               new Course
               {
                   Id = SeedingIds.CircuitsId,
                   Name = "Circuit Analysis",
                   Code = "EE101",
                   Description = "Basic circuit theory and analysis",
                   StartDate = DateTime.UtcNow.AddMonths(-1),
                   EndDate = DateTime.UtcNow.AddMonths(3),
                   CreditHours = 4,
                   TeacherId = SeedingIds.Teacher2Id
               },
               new Course
               {
                   Id = SeedingIds.LogicDesignId,
                   Name = "Digital Logic Design",
                   Code = "EE201",
                   Description = "Digital systems and logic design principles",
                   StartDate = DateTime.UtcNow.AddMonths(-1),
                   EndDate = DateTime.UtcNow.AddMonths(3),
                   CreditHours = 3,
                   TeacherId = SeedingIds.Teacher2Id
               },
               new Course
               {
                   Id = SeedingIds.CalculusId,
                   Name = "Calculus I",
                   Code = "MATH101",
                   Description = "Differential and integral calculus",
                   StartDate = DateTime.UtcNow.AddMonths(-1),
                   EndDate = DateTime.UtcNow.AddMonths(3),
                   CreditHours = 4,
                   TeacherId = null  
               }
           );
        }
    }
}
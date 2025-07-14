using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentConfigurations
{
    internal class StudentCourseConfig : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.HasOne(sc => sc.Student)
                   .WithMany(s => s.StudentCourses)
                   .HasForeignKey(sc => sc.StudentId);

            builder.HasOne(sc => sc.Course)
                   .WithMany(c => c.StudentCourses)
                   .HasForeignKey(sc => sc.CourseId);

            builder.Property(sc => sc.EnrollmentDate)
                .IsRequired()
                .HasDefaultValueSql("now()");

            builder.Property(sc => sc.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasDefaultValue(EnrollmentStatus.Enrolled);

            builder.Property(sc => sc.Grade)
                .HasMaxLength(2);

            builder.HasData(
               new StudentCourse
               {
                   Id = Guid.NewGuid(),
                   StudentId = SeedingIds.Student1Id,
                   CourseId = SeedingIds.DataStructId,
                   EnrollmentDate = DateTime.UtcNow.AddMonths(-1),
                   Status = EnrollmentStatus.Enrolled
               },
               new StudentCourse
               {
                   Id = Guid.NewGuid(),
                   StudentId = SeedingIds.Student1Id,
                   CourseId = SeedingIds.CalculusId,
                   EnrollmentDate = DateTime.UtcNow.AddMonths(-1),
                   Status = EnrollmentStatus.Enrolled
               },
               new StudentCourse
               {
                   Id = Guid.NewGuid(),
                   StudentId = SeedingIds.Student2Id,
                   CourseId = SeedingIds.DataStructId,
                   EnrollmentDate = DateTime.UtcNow.AddMonths(-1),
                   Status = EnrollmentStatus.Enrolled
               },
               new StudentCourse
               {
                   Id = Guid.NewGuid(),
                   StudentId = SeedingIds.Student2Id,
                   CourseId = SeedingIds.AlgorithmsId,
                   EnrollmentDate = DateTime.UtcNow.AddMonths(-1),
                   Status = EnrollmentStatus.Enrolled
               },
               new StudentCourse
               {
                   Id = Guid.NewGuid(),
                   StudentId = SeedingIds.Student3Id,
                   CourseId = SeedingIds.CircuitsId,
                   EnrollmentDate = DateTime.UtcNow.AddMonths(-1),
                   Status = EnrollmentStatus.Enrolled
               },
               new StudentCourse
               {
                   Id = Guid.NewGuid(),
                   StudentId = SeedingIds.Student4Id,
                   CourseId = SeedingIds.DbSystemsId,
                   EnrollmentDate = DateTime.UtcNow.AddMonths(-1),
                   Status = EnrollmentStatus.Enrolled
               },
               new StudentCourse
               {
                   Id = Guid.NewGuid(),
                   StudentId = SeedingIds.Student5Id,
                   CourseId = SeedingIds.LogicDesignId,
                   EnrollmentDate = DateTime.UtcNow.AddMonths(-1),
                   Status = EnrollmentStatus.Enrolled
               },
               new StudentCourse
               {
                   Id = Guid.NewGuid(),
                   StudentId = SeedingIds.Student5Id,
                   CourseId = SeedingIds.CalculusId,
                   EnrollmentDate = DateTime.UtcNow.AddMonths(-1),
                   Status = EnrollmentStatus.Enrolled
               }
           );
        }
    }
}
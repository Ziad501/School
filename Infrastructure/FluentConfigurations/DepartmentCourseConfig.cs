using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentConfigurations
{
    internal class DepartmentCourseConfig : IEntityTypeConfiguration<DepartmentCourse>
    {
        public void Configure(EntityTypeBuilder<DepartmentCourse> builder)
        {
            builder.HasKey(dc => new { dc.DepartmentId, dc.CourseId });

            builder.HasOne(dc => dc.Department)
                   .WithMany(d => d.DepartmentCourses)
                   .HasForeignKey(dc => dc.DepartmentId);

            builder.HasOne(dc => dc.Course)
                   .WithMany(c => c.DepartmentCourses)
                   .HasForeignKey(dc => dc.CourseId);

            builder.HasData(
               new DepartmentCourse
               {
                   Id = Guid.NewGuid(),
                   DepartmentId = SeedingIds.CsDeptId,
                   CourseId = SeedingIds.DataStructId,
                   IsCoreRequirement = true
               },
               new DepartmentCourse
               {
                   Id = Guid.NewGuid(),
                   DepartmentId = SeedingIds.CsDeptId,
                   CourseId = SeedingIds.AlgorithmsId,
                   IsCoreRequirement = true
               },
               new DepartmentCourse
               {
                   Id = Guid.NewGuid(),
                   DepartmentId = SeedingIds.CsDeptId,
                   CourseId = SeedingIds.DbSystemsId,
                   IsCoreRequirement = true
               },
               new DepartmentCourse
               {
                   Id = Guid.NewGuid(),
                   DepartmentId = SeedingIds.EeDeptId,
                   CourseId = SeedingIds.CircuitsId,
                   IsCoreRequirement = true
               },
               new DepartmentCourse
               {
                   Id = Guid.NewGuid(),
                   DepartmentId = SeedingIds.EeDeptId,
                   CourseId = SeedingIds.LogicDesignId,
                   IsCoreRequirement = false  
               },
               new DepartmentCourse
               {
                   Id = Guid.NewGuid(),
                   DepartmentId = SeedingIds.CsDeptId,
                   CourseId = SeedingIds.CalculusId,
                   IsCoreRequirement = true
               },
               new DepartmentCourse
               {
                   Id = Guid.NewGuid(),
                   DepartmentId = SeedingIds.EeDeptId,
                   CourseId = SeedingIds.CalculusId,
                   IsCoreRequirement = true
               }
           );
        }
    }
}
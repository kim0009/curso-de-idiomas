using LanguagesCourse.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguagesCourse.Configuration.Map
{
    public class StudentHistoryMap : IEntityTypeConfiguration<StudentHistory>
    {
        public void Configure(EntityTypeBuilder<StudentHistory> builder)
        {
            builder.ToTable("student_history");

            builder.HasKey(x => new { x.CourseId, x.StudentId });

            //builder.Property(x => x.Id)
            //    .IsRequired()
            //    .UseSqlServerIdentityColumn();

            builder.Property(x => x.EndDate)
                .HasColumnName("end_date");

            builder.Property(x => x.CreationDate)
                .HasColumnName("creation_date")
                .IsRequired();

            builder.HasOne(x => x.Course)
                .WithMany(q => q.StudentHistories)
                .HasForeignKey(x => x.CourseId)
                .HasConstraintName("id_course")
                .IsRequired();
            
            builder.HasOne(x => x.Student)
                .WithMany(q => q.StudentHistories)
                .HasForeignKey(x => x.StudentId)
                .HasConstraintName("id_student")
                .IsRequired();
        }
    }
}
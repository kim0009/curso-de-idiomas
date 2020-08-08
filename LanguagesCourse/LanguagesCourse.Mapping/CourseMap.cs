using LanguagesCourse.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguagesCourse.Mapping
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("course");

            builder.HasKey(x => x.Id)
               .HasName("id");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
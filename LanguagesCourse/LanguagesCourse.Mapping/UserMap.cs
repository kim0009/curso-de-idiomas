using LanguagesCourse.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguagesCourse.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(x => x.Id)
               .HasName("id");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Login)
                .HasColumnName("login")
                .HasMaxLength(20)
                .IsRequired();
            
            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
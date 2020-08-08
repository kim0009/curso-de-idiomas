using LanguagesCourse.Configuration.Map;
using LanguagesCourse.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace LanguagesCourse.Configuration
{
    public class LanguagesCourseModelContext : DbContext
    {
        private string ConnectionString { get; set; }

        public virtual DbSet<Course> Course { get; set; }

        public virtual DbSet<Student> Student { get; set; }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<StudentHistory> StudentHistory { get; set; }

        public LanguagesCourseModelContext()
        {

        }

        public LanguagesCourseModelContext(DbContextOptions<LanguagesCourseModelContext> options)
            : base(options)
        {
        }

        public LanguagesCourseModelContext(IConfiguration configuration)
            : base()
        {
            this.ConnectionString = configuration.GetConnectionString("language_course");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //var connection = new SqlConnection(this.ConnectionString);
            var connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=language_course_db;User=db;Password=12345;");
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var TypeMappging1 = Assembly.GetExecutingAssembly().GetTypes();
            var TypeMappging = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.IsClass && x.Namespace.Equals("LanguagesCourse.Configuration.Map"))
                .ToList();

            foreach (var mapping in TypeMappging)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.ApplyConfiguration(mappingClass);
            }

            //modelBuilder.ApplyConfiguration<User>(new UserMap());
            //modelBuilder.ApplyConfiguration<Student>(new StudentMap());
            //modelBuilder.ApplyConfiguration<StudentHistory>(new StudentHistoryMap());
            //modelBuilder.ApplyConfiguration<Course>(new CourseMap());
        }
    }
}
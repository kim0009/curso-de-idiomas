using System;

namespace LanguagesCourse.Entity
{
    public class StudentHistory
    {
        public DateTime CreationDate { get; set; }

        public DateTime EndDate { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
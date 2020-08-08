using System;

namespace LanguagesCourse.Model.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public DateTime CreationDate { get; set; }

        public CourseDto Course { get; set; }
    }
}
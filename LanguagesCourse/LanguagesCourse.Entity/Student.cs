using System.Collections.Generic;

namespace LanguagesCourse.Entity
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<StudentHistory> StudentHistories { get; set; }
    }
}
using LanguagesCourse.Entity;
using System.Collections.Generic;

namespace LanguagesCourse.Bunisess
{
    public interface ICourseBunisess : IBaseBunisess
    {
        bool CheckExistence(int id);

        Course GetById(int id);

        List<Course> GetAll();

        void Save(Course course);

        void Update(Course course);

        void Delete(int id);
    }
}
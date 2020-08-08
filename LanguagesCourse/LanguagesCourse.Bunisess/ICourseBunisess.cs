using LanguagesCourse.Model.Dto;

namespace LanguagesCourse.Bunisess
{
    public interface ICourseBunisess : IBaseBunisess
    {
        bool CheckExistence(int id);

        CourseDto GetById(int id);
    }
}
using LanguagesCourse.Model.Dto;

namespace LanguagesCourse.Services
{
    public interface ICourseService : IBaseService
    {
        string Test();
        bool CheckExistenceCourse(int id);

        bool Delete(int id);

        CourseDto Get(int id);

        CourseDto Save(CourseDto courseDto);
    }
}
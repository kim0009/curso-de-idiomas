using LanguagesCourse.Model.Dto;
using System.Collections.Generic;

namespace LanguagesCourse.Services
{
    public interface ICourseService : IBaseService
    {
        string Test();
        bool CheckExistenceCourse(int id);

        CourseDto Get(int id);

        List<CourseDto> GetAll();
        void Delete(int id);

        CourseDto Save(CourseDto courseDto);

        void Update(CourseDto courseDto);
    }
}
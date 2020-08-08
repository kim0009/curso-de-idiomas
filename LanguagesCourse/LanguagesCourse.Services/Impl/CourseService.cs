using LanguagesCourse.Bunisess;
using LanguagesCourse.Model.Dto;

namespace LanguagesCourse.Services.Impl
{
    public class CourseService : ICourseService
    {
        private readonly ICourseBunisess _courseBunisess;

        public CourseService(ICourseBunisess courseBunisess)
        {
            _courseBunisess = courseBunisess;
        }

        public string Test()
        {
            return "Teste de APi Ok";
        }
        public bool CheckExistenceCourse(int id)
        {
            return _courseBunisess.CheckExistence(id);
        }

        public CourseDto Get(int id)
        {
            _courseBunisess.GetById(id);
            return null;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public CourseDto Save(CourseDto courseDto)
        {
            //_courseRepository.Save();
            throw new System.NotImplementedException();
        }
    }
}
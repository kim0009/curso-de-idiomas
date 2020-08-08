using LanguagesCourse.Bunisess;
using LanguagesCourse.Model.Dto;

namespace LanguagesCourse.Services.Impl
{
    public class StudentService : IStudentService
    {
        private readonly IStudentBunisess _studentBunisess;

        private readonly ICourseService _courseService;

        private readonly IStudentHistoryService _studentHistoryService;

        public StudentService(IStudentBunisess studentBunisess, ICourseService courseService, IStudentHistoryService studentHistoryService)
        {
            _studentBunisess = studentBunisess;
            _courseService = courseService;
            _studentHistoryService = studentHistoryService;
        }

        public void Save(StudentDto studentDto)
        {
            if (_courseService.CheckExistenceCourse(studentDto.Course.Id))
            {
                //_studentHistoryService

            }
        }
    }
}
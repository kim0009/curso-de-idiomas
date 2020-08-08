using AutoMapper;
using LanguagesCourse.Bunisess;
using LanguagesCourse.Entity;
using LanguagesCourse.Model.Dto;
using System.Collections.Generic;

namespace LanguagesCourse.Services.Impl
{
    public class CourseService : ICourseService
    {
        private readonly ICourseBunisess _courseBunisess;

        private readonly IMapper _mapper;
        
        public CourseService(ICourseBunisess courseBunisess, IMapper mapper)
        {
            _courseBunisess = courseBunisess;
            _mapper = mapper;
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
            return _mapper.Map<CourseDto>(_courseBunisess.GetById(id)); 
        }

        public  void Delete(int id)
        {
            _courseBunisess.Delete(id);
        }

        public List<CourseDto> GetAll()
        {
            return _mapper.Map<List<CourseDto>>(_courseBunisess.GetAll());
        }

        public CourseDto Save(CourseDto courseDto)
        {
            _courseBunisess.Save(_mapper.Map<CourseDto, Course>(courseDto));
            return null;
        }

        public void Update(CourseDto courseDto)
        {
            _courseBunisess.Update(_mapper.Map<CourseDto, Course>(courseDto));
        }
    }
}
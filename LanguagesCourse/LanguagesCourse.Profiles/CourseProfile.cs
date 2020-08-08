using AutoMapper;
using LanguagesCourse.Entity;
using LanguagesCourse.Model.Dto;

namespace LanguagesCourse.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.CountStudents, opt => opt.MapFrom(x => x.StudentHistories != null ? x.StudentHistories.Count : 0))
                .ReverseMap()
                .ForMember(dest => dest.StudentHistories, opt => opt.Ignore());
        }
    }
}
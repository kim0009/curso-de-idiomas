using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace LanguagesCourse.Profiles
{
    public static class ProfileConfig
    {
        public static void RegisterProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CourseProfile));
        }
    }
}